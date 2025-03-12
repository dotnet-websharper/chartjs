@echo off
setlocal

dotnet tool restore

dotnet paket update -g wsbuild --no-install
if errorlevel 1 exit /b %errorlevel%

set _Add-t=""
set FirstArg=%1
if not "%FirstArg%"=="" if not "%FirstArg:~0,1%"=="-" set _Add-t=1
if "%_Add-t%"=="1" (
  dotnet fsi ./build.fsx -t %*
) else (
  dotnet fsi ./build.fsx %*
)
