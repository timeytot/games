param(
    [string]$GameDir = "C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure"
)

$ErrorActionPreference = "Stop"

if (!(Test-Path "$GameDir\Wrath_Data\Managed\Assembly-CSharp.dll")) {
    throw "WotR install not found at: $GameDir"
}

$env:WOTR_DIR = $GameDir

Push-Location $PSScriptRoot
try {
    dotnet build .\HansenRuntimeEquipFix.csproj -c Release

    $dll = Join-Path $PSScriptRoot "bin\Release\HansenRuntimeEquipFix.dll"
    if (!(Test-Path $dll)) {
        throw "Build finished but DLL was not found: $dll"
    }

    $dest = Join-Path $GameDir "Mods\HansenRuntimeEquipFix"
    New-Item -ItemType Directory -Force -Path $dest | Out-Null
    Copy-Item $dll (Join-Path $dest "HansenRuntimeEquipFix.dll") -Force
    Copy-Item (Join-Path $PSScriptRoot "Info.json") (Join-Path $dest "Info.json") -Force

    Write-Host ""
    Write-Host "Installed to: $dest"
    Write-Host "Start WotR, load the Hansen save, open Unity Mod Manager, and click the Equip button."
}
finally {
    Pop-Location
}
