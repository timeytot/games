$ErrorActionPreference = "Stop"

# Confirmed from appmanifest_1184370.acf:
# appid 1184370, installdir "Pathfinder Second Adventure",
# LauncherPath "C:\Program Files (x86)\Steam\steam.exe".
# The install root contains Wrath.exe and UnityCrashHandler64.exe.
$steam = "C:\Program Files (x86)\Steam\steam.exe"
$appId = "1184370"
$gameProcess = "Wrath"
$refresh = Join-Path $PSScriptRoot "refresh_current_snapshot.cmd"

if (-not (Test-Path -LiteralPath $steam)) {
    throw "Steam launcher recorded in the WotR appmanifest was not found."
}
if (-not (Test-Path -LiteralPath "D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Wrath.exe")) {
    throw "Wrath.exe recorded in the WotR install directory was not found."
}

Start-Process -FilePath $steam -ArgumentList @("-applaunch", $appId)
Write-Output "LAUNCHED steam -applaunch $appId"

$deadline = (Get-Date).AddMinutes(5)
$seen = $false
while ((Get-Date) -lt $deadline) {
    $running = @(Get-Process -Name $gameProcess -ErrorAction SilentlyContinue)
    if ($running.Count -gt 0) {
        $seen = $true
        break
    }
    Start-Sleep -Seconds 2
}
if (-not $seen) {
    Write-Output "GAME_DID_NOT_START"
    exit 1
}
Write-Output "GAME_RUNNING"
while (@(Get-Process -Name $gameProcess -ErrorAction SilentlyContinue).Count -gt 0) {
    Start-Sleep -Seconds 3
}
Write-Output "GAME_EXITED"
& $refresh
exit $LASTEXITCODE
