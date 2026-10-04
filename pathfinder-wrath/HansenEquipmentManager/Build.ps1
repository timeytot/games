param(
    [string]$GameDir = "C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure"
)

$ErrorActionPreference = "Stop"
$managed = Join-Path $GameDir "Wrath_Data\Managed"
if (!(Test-Path "$managed\Assembly-CSharp.dll")) {
    throw "WotR install not found at: $GameDir"
}

$csc = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\Roslyn\csc.exe"
if (!(Test-Path $csc)) {
    throw "Visual Studio Build Tools csc.exe was not found."
}

$fx = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
$root = $PSScriptRoot
$outDir = Join-Path $root "bin\Release"
New-Item -ItemType Directory -Force -Path $outDir | Out-Null
$dll = Join-Path $outDir "HansenEquipmentManager.dll"

& $csc /nologo /target:library /langversion:latest /nullable:disable `
    /out:$dll `
    (Join-Path $root "UI\Main.cs") `
    (Join-Path $root "Core\Models.cs") `
    (Join-Path $root "Core\ProfileLoader.cs") `
    (Join-Path $root "Core\EquipmentScanner.cs") `
    (Join-Path $root "Core\EquipmentValidator.cs") `
    (Join-Path $root "Core\EquipmentExecutor.cs") `
    (Join-Path $root "Core\CharacterAnalyzer.cs") `
    (Join-Path $root "Core\ItemEvaluator.cs") `
    (Join-Path $root "Core\PartyOptimizer.cs") `
    (Join-Path $root "Core\EquipmentAdvisor.cs") `
    /r:"$managed\Assembly-CSharp.dll" `
    /r:"$managed\Newtonsoft.Json.dll" `
    /r:"$managed\UnityEngine.CoreModule.dll" `
    /r:"$managed\UnityEngine.IMGUIModule.dll" `
    /r:"$managed\UnityModManager\UnityModManager.dll" `
    /r:"$fx\mscorlib.dll" `
    /r:"$fx\System.dll" `
    /r:"$fx\System.Core.dll"
if ($LASTEXITCODE -ne 0) {
    throw "csc failed with exit code $LASTEXITCODE"
}

$dest = Join-Path $GameDir "Mods\HansenEquipmentManager"
New-Item -ItemType Directory -Force -Path $dest | Out-Null
Copy-Item $dll (Join-Path $dest "HansenEquipmentManager.dll") -Force
Copy-Item (Join-Path $root "Info.json") (Join-Path $dest "Info.json") -Force
$profileDest = Join-Path $dest "Profiles"
New-Item -ItemType Directory -Force -Path $profileDest | Out-Null
Copy-Item (Join-Path $root "Profiles\*.json") $profileDest -Force
$ruleDest = Join-Path $dest "BuildRules"
New-Item -ItemType Directory -Force -Path $ruleDest | Out-Null
Copy-Item (Join-Path $root "BuildRules\*.json") $ruleDest -Force

$oldInfo = Join-Path $GameDir "Mods\HansenRuntimeEquipFix\Info.json"
$oldOff = Join-Path $GameDir "Mods\HansenRuntimeEquipFix\Info.json.disabled"
if ((Test-Path $oldInfo) -and !(Test-Path $oldOff)) {
    Move-Item $oldInfo $oldOff
}

Write-Host "Installed to: $dest"
Write-Host "Old HansenRuntimeEquipFix Info.json was disabled if it was still active."
