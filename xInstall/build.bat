@SET DEVENV="C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe"

@DEL *.exe
@CD ..
@DEL *.exe
@DEL setup.nsi
@RMDIR /S /Q absToTango\absToTango\bin
@RMDIR /S /Q absToTango\absToTango\obj
@RMDIR /S /Q ToTangoXport\ToTangoXport\bin
@RMDIR /S /Q ToTangoXport\ToTangoXport\obj

@ECHO.
@ECHO.
@ECHO   CLEAN UP COMPLETE !!
@ECHO.
@PAUSE
@CLS
@COPY xInstall\setup.nsi .

%DEVENV% absToTango\absToTango.sln /Build
%DEVENV% ToTangoXport\ToTangoXport.sln /Build
COPY  absToTango\absToTango\mapping.csv             ToTangoXport\ToTangoXport\bin\Debug
COPY  absToTango\absToTango\NLog.config             ToTangoXport\ToTangoXport\bin\Debug
COPY  ToTangoXport\ToTangoXport\sample.ToTango      ToTangoXport\ToTangoXport\bin\Debug
COPY  ToTangoXport\ToTangoXport\*.ps1               ToTangoXport\ToTangoXport\bin\Debug

@ECHO.
@DEL /F /S *.pdb 
@PING 127.0.0.1 > nul

@COLOR 07
SET NSIS="%ProgramFiles%\NSIS\makensis.exe"
IF NOT EXIST %NSIS% SET NSIS="%ProgramFiles(x86)%\NSIS\makensis.exe"
CALL %NSIS% setup.nsi
@ECHO.
@PING 127.0.0.1 > nul
@MOVE *.exe xInstall
DEL setup.nsi
