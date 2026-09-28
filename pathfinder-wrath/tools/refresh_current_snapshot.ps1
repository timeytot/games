$ErrorActionPreference = "Stop"
$repo = "C:\Users\timeg\Desktop\download\games"
$wrath = Join-Path $repo "pathfinder-wrath"
$current = Join-Path $wrath "current"
$temp = Join-Path $current "temp"
$saves = "C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games"
$cheat = "D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure\Bundles\cheatdata.json"
$extractor = Join-Path $wrath "tools\extract_wotr_save.py"
$lock = Join-Path $temp "refresh.lock"

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

    $driveRoot = $null
    $db = Join-Path $env:LOCALAPPDATA "Google\DriveFS\root_preference_sqlite.db"
    if (Test-Path $db) {
        $mount = python -c "import sqlite3,os; p=os.path.expandvars(r'%LOCALAPPDATA%\Google\DriveFS\root_preference_sqlite.db'); c=sqlite3.connect('file:%s?mode=ro'%p.replace('\\','/'), uri=True); rows=list(c.execute('select last_mount_point from media where name=?', ('Google Drive',))); print(rows[0][0] if rows else '')"
        if ($mount -and (Test-Path $mount)) {
            $child = Get-ChildItem -Path $mount -Directory | Where-Object { $_.Name -eq "我的云端硬盘" } | Select-Object -First 1
            if ($child) { $driveRoot = $child.FullName }
        }
    }
    if ($driveRoot) {
        $driveCurrent = Join-Path $driveRoot "games\pathfinder-wrath\current"
        New-Item -ItemType Directory -Force -Path $driveCurrent | Out-Null
        Copy-Item $copy (Join-Path $driveCurrent "Latest_Save.zks") -Force
        foreach ($name in @("Current_Save.json","Party_Current.json","Kestoglyr_Current.json","Horse_Current.json","Current_Report.md")) {
            Copy-Item (Join-Path $current $name) (Join-Path $driveCurrent $name) -Force
        }
        Write-Output "DRIVE_OK $driveCurrent"
    } else {
        Write-Output "DRIVE_SKIP no confirmed Google Drive folder"
    }

    Set-Location $repo
    git add -- pathfinder-wrath/current pathfinder-wrath/README.md pathfinder-wrath/tools .gitignore
    $staged = git diff --cached --name-only
    if (-not $staged) {
        Write-Output "NO_STAGED_CHANGES"
        exit 0
    }
    git commit -m "snapshot: update current WotR save state"
    git push origin main
    Write-Output "PUSH_OK $sha $($newest.Name)"
} finally {
    if (Test-Path $lock) { Remove-Item $lock -Force }
}
