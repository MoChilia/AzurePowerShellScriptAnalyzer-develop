<#
    .SYNOPSIS
        The script to find examples in ".md" and analyze the examples by custom rules.
    .NOTES
        File Name: Measure-MarkdownOrScript.ps1
#>

#Requires -Modules PSScriptAnalyzer

[CmdletBinding(DefaultParameterSetName = "Markdown")]
param (
    [Parameter(Mandatory, HelpMessage = "Markdown searching paths. Empty for current path. Supports wildcard.", ParameterSetName = "Markdown")]
    [AllowEmptyString()]
    [string[]]$MarkdownPaths,
    [Parameter(Mandatory, HelpMessage = "PowerShell scripts searching paths. Empty for current path. Supports wildcard.", ParameterSetName = "Script")]
    [AllowEmptyString()]
    [string[]]$ScriptPaths,
    [Parameter(HelpMessage = "PSScriptAnalyzer custom rules paths. Empty for current path. Supports wildcard.")]
    [string[]]$RulePaths,
    [switch]$Recurse,
    [switch]$IncludeDefaultRules,
    [string]$OutputFolder = "output",
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$AnalyzeScriptsInFile,
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$OutputScriptsInFile,
    [switch]$OutputResultsByModule,
    [switch]$CleanScripts
)

. $PSScriptRoot\utils.ps1

# create "ScriptsByExample" folder
# @() creates an empty array
if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    $ScriptsByExampleFolder = "ScriptsByExample"
    $scaleTable = @()
    $missingTable = @()
    $deletePromptAndSeparateOutputTable = @()
}
$analysisResultsTable = @()

# Clean caches, remove files in "output" folder
if ($OutputScriptsInFile.IsPresent) {
    Remove-Item $OutputFolder\$ScriptsByExampleFolder -Recurse -ErrorAction SilentlyContinue
}
Remove-Item $OutputFolder\*.csv -Recurse -ErrorAction SilentlyContinue
# find examples in ".md", output ".ps1"
if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    $MarkdownPathContent = Get-Content $MarkdownPaths
    (Get-ChildItem $MarkdownPathContent) | foreach{
        if ($_ -cmatch ".*\.md" -and $_.BaseName -cmatch "^([A-Z][a-z]+)+-([A-Z][a-z0-9]*)+$") {
            Write-Output "Searching in file $($_.FullName) ..."
            $cmdlet = $_.BaseName
            $result = Measure-SectionMissingAndOutputScript $module $cmdlet $_.FullName `
                -OutputScriptsInFile:$OutputScriptsInFile.IsPresent `
                -OutputFolder $OutputFolder\$ScriptsByExampleFolder
            $scaleTable += $result.Scale
            $missingTable += $result.Missing
            $deletePromptAndSeparateOutputTable += $result.DeletePromptAndSeparateOutput
        }
    }
    # @() + (Get-Item $MarkdownPaths) + (Get-ChildItem $MarkdownPaths -Recurse:$Recurse.IsPresent -Attributes Directory -Filter help) + (Get-ChildItem $MarkdownPaths -Recurse:$Recurse.IsPresent -Attributes Directory -Filter Az.*) | foreach {
    #     # Parent folder name
    #     $module = (Get-Item $_).Name -eq "help" ? (Get-ChildItem $_.Parent -Attributes !Directory -Filter *.psd1)[0].BaseName : (Get-Item $_).Name
    #     Get-ChildItem $_ -Attributes !Directory -Filter *.md | foreach {
    #         # exclude Az.*.md and README.md
    #         #if ($_.BaseName -cmatch "^([A-Z][a-z]+)+-([A-Z][a-z0-9]*)+$" -and $_.Directory.Name -cmatch "^help$|^Az\.\w+$") {
    #         if ($_.BaseName -cmatch "^([A-Z][a-z]+)+-([A-Z][a-z0-9]*)+$") {
    #             Write-Output "Searching in file $($_.FullName) ..."
    #             $cmdlet = $_.BaseName
    #             $result = Measure-SectionMissingAndOutputScript $module $cmdlet $_.FullName `
    #                 -OutputScriptsInFile:$OutputScriptsInFile.IsPresent `
    #                 -OutputFolder $OutputFolder\$ScriptsByExampleFolder
    #             $scaleTable += $result.Scale
    #             $missingTable += $result.Missing
    #             $deletePromptAndSeparateOutputTable += $result.DeletePromptAndSeparateOutput
    #         }
    #     }
    # }
    if ($AnalyzeScriptsInFile.IsPresent) {
        $ScriptPaths = "$OutputFolder\$ScriptsByExampleFolder"
    }
    # Summarize searching results
    $null = New-Item -ItemType Directory -Path $OutputFolder -ErrorAction SilentlyContinue
    $scaleTable | Export-Csv "$OutputFolder\Scale.csv" -NoTypeInformation
    $missingTable | where {$_ -ne $null} | Export-Csv "$OutputFolder\Missing.csv" -NoTypeInformation
    $deletePromptAndSeparateOutputTable | where {$_ -ne $null} | Export-Csv "$OutputFolder\DeletingSeparating.csv" -NoTypeInformation
}


# Analyze scripts
if ($PSCmdlet.ParameterSetName -eq "Script" -or $AnalyzeScriptsInFile.IsPresent) {
    $analysisResultsTable = @()
    @() + (Get-Item $ScriptPaths) + (Get-ChildItem $ScriptPaths -Recurse:$Recurse.IsPresent -Attributes Directory) | foreach {
        # Parent folder name
        $module = (Get-Item $_).Name
        $analysisResults = @()
        # read and analyze ".ps1" in \ScriptsByExample
        Get-ChildItem $_ -Attributes !Directory -Filter "*.ps1" -ErrorAction Stop | foreach {
            Write-Output "Analyzing file $($_.FullName) ..."
            $analysisResults += Get-ScriptAnalyzerResult $module $_.FullName $RulePaths -IncludeDefaultRules:$IncludeDefaultRules.IsPresent -ErrorAction Continue
        }
        if ($OutputResultsByModule.IsPresent -and (Get-ChildItem $_ -Attributes !Directory -Filter "*.ps1").Count -ne 0) {
            $analysisResults | Export-Csv "$OutputFolder\$module.csv" -NoTypeInformation
        }
        $analysisResultsTable += $analysisResults
    }
    # Summarize analysis results, output in Result.csv
    $analysisResultsTable | where {$_ -ne $null} | Export-Csv "$OutputFolder\Results-$(Get-Date -UFormat %s).csv" -NoTypeInformation

    # $s=Get-Date;
    # $analysisResults = Get-ScriptAnalyzerResult "Test" "Add-AzEnvironment.ps1" $RulePaths -IncludeDefaultRules:$IncludeDefaultRules.IsPresent -ErrorAction Continue
    # $e=Get-Date; ($e - $s).TotalSeconds
    # $analysisResults | where {$_ -ne $null} | Export-Csv "$OutputFolder\Results-$(Get-Date -UFormat %s).csv" -NoTypeInformation
}

# Clean caches
if ($CleanScripts.IsPresent) {
    Remove-Item $ScriptPaths -Exclude *.csv -Recurse -ErrorAction Continue
}
