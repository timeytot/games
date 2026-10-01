<#
.SYNOPSIS
Extract the newest Wrath of the Righteous save for one GameId into lich/current.

.DESCRIPTION
Finds the newest .zks whose header GameId matches, runs extract_wotr_save.py, and
writes the snapshot under pathfinder-wrath/lich/current. Extraction always runs.

A local git commit is optional. Pass -Commit to stage and commit the snapshot
on the current branch. Pass -Push to do that commit and then push the current
branch with `git push origin HEAD`. Push is off unless -Push is set. This script
does not assume origin/main.

.PARAMETER Repo
Git repository root. Environment: WOTR_REPO. Default: the folder that contains
pathfinder-wrath, two levels above this script.

.PARAMETER Saves
Owlcat Saved Games directory. Environment: WOTR_SAVES. Default: the current
user's LocalLow Pathfinder Wrath Of The Righteous Saved Games folder.

.PARAMETER GameId
header.json GameId to keep. Environment: WOTR_GAME_ID. Default: the FaN lich id.

.PARAMETER CheatData
Path to the game's Bundles/cheatdata.json. Environment: WOTR_CHEATDATA.
Default: the usual Steam install of Pathfinder Second Adventure.

.PARAMETER Commit
Stage and commit the extracted snapshot locally. Does not push.

.PARAMETER Push
Commit the snapshot, then push the current branch to origin. Implies -Commit.
#>
param(
    [string]$Repo = $(if ($env:WOTR_REPO) { $env:WOTR_REPO } else { (Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path }),
    [string]$Saves = $(if ($env:WOTR_SAVES) { $env:WOTR_SAVES } else { Join-Path $env:USERPROFILE "AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games" }),
    [string]$GameId = $(if ($env:WOTR_GAME_ID) { $env:WOTR_GAME_ID } else { "7ea3d466491c4249aec2742271c2e71a" }),
    [string]$CheatData = $(if ($env:WOTR_CHEATDATA) { $env:WOTR_CHEATDATA } else { "C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Bundles\cheatdata.json" }),
    [switch]$Commit,
    [switch]$Push
)

$ErrorActionPreference = "Stop"
$doCommit = [bool]$Commit -or [bool]$Push

$wrath = Join-Path $Repo "pathfinder-wrath"
$current = Join-Path $wrath "lich\current"
$tempRoot = if ($env:TEMP) { $env:TEMP } else { [System.IO.Path]::GetTempPath() }
$temp = Join-Path $tempRoot "WotR_Current_Snapshot"
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
    if ([string]::IsNullOrWhiteSpace($Repo) -or !(Test-Path $Repo)) {
        throw "Repo was not found: $Repo"
    }
    if ([string]::IsNullOrWhiteSpace($Saves) -or !(Test-Path $Saves)) {
        throw "Saves folder was not found: $Saves"
    }
    if ([string]::IsNullOrWhiteSpace($GameId)) {
        throw "GameId is empty. Pass -GameId or set WOTR_GAME_ID."
    }
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $matchedSaves = New-Object System.Collections.Generic.List[System.IO.FileInfo]
    foreach ($file in (Get-ChildItem -Path $Saves -Filter *.zks -Recurse -File)) {
        try {
            $zip = [System.IO.Compression.ZipFile]::OpenRead($file.FullName)
            try {
                $entry = $zip.GetEntry("header.json")
                if (-not $entry) { continue }
                $reader = New-Object System.IO.StreamReader($entry.Open())
                try { $header = $reader.ReadToEnd() | ConvertFrom-Json }
                finally { $reader.Dispose() }
                if ($header.GameId -eq $GameId) { $matchedSaves.Add($file) }
            } finally { $zip.Dispose() }
        } catch {
            Write-Output "SKIP_SAVE $($file.Name) $($_.Exception.Message)"
        }
    }
    $newest = $matchedSaves | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    if (-not $newest) {
        throw "No save found for game $GameId."
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
        --cheatdata $CheatData `
        --outdir $current `
        --sha256 $sha `
        --source-file $newest.FullName `
        --last-write-time $stamp `
        --size $newest.Length
    if ($LASTEXITCODE -ne 0) { throw "extractor failed: $LASTEXITCODE" }

    if (-not $doCommit) {
        Write-Output "EXTRACT_OK $sha $($newest.Name)"
    } else {
        Set-Location $Repo
        $paths = @("pathfinder-wrath/lich/README.md", "pathfinder-wrath/tools")
        foreach ($name in $currentFiles) {
            $paths += "pathfinder-wrath/lich/current/$name"
        }
        git add -- $paths
        $staged = git diff --cached --name-only
        if (-not $staged) {
            Write-Output "NO_STAGED_CHANGES"
        } else {
            git commit -m "snapshot: update current WotR save state"
            if ($Push) {
                git push origin HEAD
                Write-Output "PUSH_OK $sha $($newest.Name)"
            } else {
                Write-Output "COMMIT_OK $sha $($newest.Name)"
            }
        }
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
