@echo off
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0Play_WotR_And_Sync.ps1"
exit /b %ERRORLEVEL%
