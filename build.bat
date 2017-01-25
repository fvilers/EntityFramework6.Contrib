@echo off
erase dist\*.nupkg
msbuild src\EntityFramework6.Contrib.sln /p:Configuration=Release