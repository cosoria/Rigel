if "%~1"=="" build Build DEV
if "%~2"=="" build %~1 DEV

:initializesdk
if "%WindowsSdkDir%" neq "" goto build
if exist "%ProgramFiles(x86)%\Microsoft Visual Studio 11.0\VC\vcvarsall.bat" goto initializeon64
if exist "%ProgramFiles%\Microsoft Visual Studio 11.0\VC\vcvarsall.bat" goto initializeon32
echo "Unable to detect suitable environment. Build may not succeed."
goto build


:initializeon32
call "%ProgramFiles%\Microsoft Visual Studio 11.0\VC\vcvarsall.bat" x86
goto build

:initializeon64
call "%ProgramFiles(x86)%\Microsoft Visual Studio 11.0\VC\vcvarsall.bat" x86
goto build


:build
msbuild /t:%~1 /property:ENV_CONFIG=%~2 source/Rigel.build 

goto end


:end