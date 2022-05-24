# How to run the AzurePowerShellScriptAnalyzer
1. Install PowerShell on Windows, Linux, and macOS, please refer to https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.2
2. Install PSScriptAnalyzer from PowerShell Gallery
```powershell
install-module PSScriptAnalyzer
```
3. Install AzPreview from PowerShell Gallery
```powershell
install-module AzPreview
```
4. Clone the git repersitory (needs git)
```
git clone https://github.com/ziyuezh576/AzurePowerShellScriptAnalyzer.git
```
5. Navigate to the source directory
```
cd path/to/AzurePowerShellScriptAnalyzer
```
6. Run the AzurePowerShellScriptAnalyzer
```powershell
.\Measure-MarkdownOrScript.ps1 -MarkdownPaths "C:\path\MarkdownPaths"  -RulePaths ".\AnalyzeRules\\*.psm1" -Recurse -AnalyzeScriptsInFile -OutputScriptsInFile -OutputResultsByModule
```

**Supported PowerShell Versions and Platforms**
* Windows PowerShell 3.0 or greater
* PowerShell Core 7.0.3 or greater on Windows/Linux/macOS