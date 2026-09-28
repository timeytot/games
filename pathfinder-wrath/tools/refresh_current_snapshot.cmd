@echo off
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0refresh_current_snapshot.ps1"
exit /b %ERRORLEVEL%
