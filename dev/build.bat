cd ../src/FTFlash/
rmdir /s /q bin
dotnet publish --configuration Release
cd bin/Release/
explorer .
pause