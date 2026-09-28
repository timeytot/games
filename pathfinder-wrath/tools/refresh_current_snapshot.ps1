$ErrorActionPreference = "Stop"
$repo = "C:\Users\timeg\Desktop\download\games"
$wrath = Join-Path $repo "pathfinder-wrath"
$current = Join-Path $wrath "current"
$temp = Join-Path $env:TEMP "WotR_Current_Snapshot"
$saves = "C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games"
$cheat = "D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Bundles\cheatdata.json"
$extractor = Join-Path $wrath "tools\extract_wotr_save.py"
$lock = Join-Path $temp "refresh.lock"
$currentFiles = @(
    "Current_Save.json",
    "Party_Current.json",
    "Kestoglyr_Current.json",
    "Horse_Current.json",
    "Current_Report.md",
    "Current_Save.sha256"
)

New-Item -ItemType Directory -Force -Path $temp | Out-Null
if (Test-Path $lock) {
    $age = (Get-Date) - (Get-Item $lock).LastWriteTime
    if ($age.TotalMinutes -lt 15) {
        Write-Output "Another refresh is still running. Exit."
        exit 0
    }
}
Set-Content -Path $lock -Value $PID -Encoding ascii
try {
    $newest = Get-ChildItem -Path $saves -Filter *.zks -Recurse -File |
        Sort-Object LastWriteTime -Descending |
        Select-Object -First 1
    if (-not $newest) {
        throw "No .zks files found."
    }
    $sha = (Get-FileHash -Algorithm SHA256 -Path $newest.FullName).Hash.ToLower()
    $shaFile = Join-Path $current "Current_Save.sha256"
    if (Test-Path $shaFile) {
        $old = (Get-Content -Path $shaFile -Raw).Trim().ToLower()
        if ($old -eq $sha) {
            Write-Output "NO_CHANGE $sha $($newest.Name)"
            exit 0
        }
    }

    $copy = Join-Path $temp $newest.Name
    Copy-Item -Path $newest.FullName -Destination $copy -Force
    $stamp = $newest.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")
    python $extractor `
        --save $copy `
        --cheatdata $cheat `
        --outdir $current `
        --sha256 $sha `
        --source-file $newest.FullName `
        --last-write-time $stamp `
        --size $newest.Length
    if ($LASTEXITCODE -ne 0) { throw "extractor failed: $LASTEXITCODE" }

    Set-Location $repo
    $paths = @("pathfinder-wrath/README.md", "pathfinder-wrath/tools")
    foreach ($name in $currentFiles) {
        $paths += "pathfinder-wrath/current/$name"
    }
    git add -- $paths
    $staged = git diff --cached --name-only
    if (-not $staged) {
        Write-Output "NO_STAGED_CHANGES"
    } else {
        git commit -m "snapshot: update current WotR save state"
        git push origin main
        Write-Output "PUSH_OK $sha $($newest.Name)"
    }

    python (Join-Path $wrath "tools\copy_current_to_drive.py") $current $copy
    if ($LASTEXITCODE -ne 0) {
        Write-Output "DRIVE_WARN copy failed: $LASTEXITCODE"
    }
} catch {
    Write-Output "REFRESH_FAILED $($_.Exception.Message)"
    exit 1
} finally {
    if (Test-Path $lock) { Remove-Item $lock -Force }
}
