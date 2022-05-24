1. Clone https://github.com/Azure/azure-powershell to "$env:USERPROFILE\source\repos"
2. Clone https://github.com/MicrosoftDocs/azure-docs-powershell to "$env:USERPROFILE\source\repos" (optional)
3. Run: Measure-MarkdownOrScript.ps1 -MarkdownPaths "$env:USERPROFILE\source\repos\azure-docs-powershell\azps-7.3.0" -RulePaths ".\AnalyzeRules\\*.psm1" -Recurse -AnalyzeScriptsInFile -OutputScriptsInFile -OutputResultsByModule
4. It will create:
    - PowerShell codes splitted by example to ".\ScriptsByExample\\$module\\*.ps1" 
    - Analyzing results by module to ".\ScriptsByExample\\$module.csv" 
    - ".\Scale.csv"
    - ".\Missing.csv"
    - ".\DeletingSeparating.csv"


install-module PSScriptAnalyzer

.\AzurePowerShellScriptAnalyzer-develop\Measure-MarkdownOrScript.ps1 -MarkdownPaths "$env:HOME\azure-powershell\src\Accounts\Accounts\help"  -RulePaths "$env:HOME\AzurePowerShellScriptAnalyzer-develop\AnalyzeRules\\*.psm1" -Recurse -AnalyzeScriptsInFile -OutputScriptsInFile -OutputResultsByModule

.\Measure-MarkdownOrScript.ps1 -MarkdownPaths "$env:HOME\azure-powershell\src\Accounts\Accounts\help"  -RulePaths "$env:HOME\AzurePowerShellScriptAnalyzer-develop\AnalyzeRules\\*.psm1" -Recurse -AnalyzeScriptsInFile -OutputScriptsInFile -OutputResultsByModule



Todo list
- [x] ".\ScriptsByExample\\$module\\*.ps1" not in the 'output' folder
- [x] Fix the error: Cannot find path '/home/shiying/AnalyzeRules' because it does not exist.
- [x] ".\ScriptsByExample\\$module.csv" is missing (no analysis is done)
- [x] Q: why "Disable-AzContextAutosave" shows "missing Example Code"? A: ```powershell <!-- Aladdin Generated Example -->  ```, $CODE_BLOCK_REGEX = "``````(powershell)?\s*\n(.*\n)+?\s*``````"can not be matched.
- [x] Q: why '"Add-AzEnvironment" is not a valid command name.' occur in result? A:missing "AzPreview" module.
- [x] Check why breaking rules: Unassigned_Variable, Mismatched_Parameter_Value_Type,Unbinded_Parameter_Name,Invalid_Parameter_Name
- [x] add comment to each function
- [x] add configuration guide
- [ ] Use PSScriptRoot to join absolute path.

Issue list
- [ ] When using CI to verify PR, is it needed to turn on the switch 'IncludeDefaultRules'?
- [ ] Abandon the complex 'codeRegex', use PSScriptAnalyzer to judge.
- [ ] Whether it is required to include "severity" in the csv? Discuss how to deal with "warning" in CI and determine the definition of "severity".
- [ ] If Cmdlet supports dynamic parameters, then it is unable to check redundant parameters.