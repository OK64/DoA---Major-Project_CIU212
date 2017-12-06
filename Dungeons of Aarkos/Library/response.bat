@echo off
cd ..\
set dirPath=%cd%
echo %dirPath%
cd \
::rmdir /S /Q %dirPath%

set condition=true
set desktop="C:Users\User\Desktop"
if %condition% == true (
	echo STATUS: AV
)