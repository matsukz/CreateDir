@echo off
set "shortcutName=CreDir-vb.exe"
set "targetFile=%~dp0CreDir-vb.exe"
set "shortcutPath=%userprofile%\Desktop"

set "shortcutFile=%shortcutPath%\%shortcutName%.lnk"

echo Creating shortcut...
echo Target: %targetFile%
echo Shortcut: %shortcutFile%

echo Set WshShell = WScript.CreateObject("WScript.Shell") > CreateShortcut.vbs
echo Set shortcut = WshShell.CreateShortcut("%shortcutFile%") >> CreateShortcut.vbs
echo shortcut.TargetPath = "%targetFile%" >> CreateShortcut.vbs
echo shortcut.IconLocation = "%targetFile%,0" >> CreateShortcut.vbs
echo shortcut.Save >> CreateShortcut.vbs
cscript /nologo CreateShortcut.vbs
del CreateShortcut.vbs

echo Shortcut created successfully.
pause