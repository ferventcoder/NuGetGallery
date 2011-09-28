@echo off

SET DIR=%~dp0%
if '%1' == 'chocolatey' goto chocolatey

%windir%\System32\WindowsPowerShell\v1.0\powershell.exe -NoProfile -ExecutionPolicy unrestricted -Command "& '%DIR%Build-Solution.ps1' %*"
if %ERRORLEVEL% NEQ 0 goto errors

goto :eof

:chocolatey
call "%DIR%chocolatey\build.bat"
goto :eof

:errors
EXIT /B %ERRORLEVEL%