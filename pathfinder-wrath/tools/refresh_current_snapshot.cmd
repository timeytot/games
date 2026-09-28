@echo off
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0refresh_current_snapshot.ps1"
set ERR=%ERRORLEVEL%
echo.
echo Exit code: %ERR%
pause
exit /b %ERR%
