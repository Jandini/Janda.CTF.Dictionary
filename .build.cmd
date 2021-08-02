@echo off
:: This build overrides dots build
dotnet build -c Release src\Janda.CTF.Dictionary.Builder
cd bin\Release\netcoreapp3.1
Janda.CTF.Dictionary.Builder.exe --name B001
cd ..\..\..
dotnet build src\Janda.CTF.Dictionary.sln

