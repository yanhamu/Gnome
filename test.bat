@echo off

nuget install -Verbosity quiet -OutputDirectory packages -Version 4.6.519 OpenCover
nuget install -Verbosity quiet -OutputDirectory packages -Version 3.0.2 ReportGenerator

set OPENCOVER=%cd%/packages/OpenCover.4.6.519/tools/OpenCover.Console.exe
set REPORTGENERATOR=%cd%/packages/ReportGenerator.3.0.2/tools/ReportGenerator.exe

set CONFIG=Debug
set DOTNET_BUILD_ARGS=-c %CONFIG%
set DOTNET_TEST_ARGS=%DOTNET_BUILD_ARGS%

echo CLI args: %DOTNET_BUILD_ARGS%

echo Restoring
dotnet restore

echo Building
dotnet build %DOTNET_BUILD_ARGS%

echo Testing
set coverage=coverage
rmdir %coverage% /S /Q
mkdir %coverage%

echo Calculating coverage with OpenCover
%OPENCOVER% ^
  -target:"c:\Program Files\dotnet\dotnet.exe" ^
  -targetargs:"test -f netcoreapp2.0 %DOTNET_TEST_ARGS%" ^
  -mergeoutput ^
  -hideskipped:File ^
  -output:%coverage%/coverage.xml ^
  -oldStyle ^
  -filter:"+[Gnome*]* -[*Tests]*" ^
  -searchdirs:%testdir%/bin/%CONFIG%/netcoreapp2.0 ^
  -register:user

echo Generating HTML report
%REPORTGENERATOR% ^
  -reports:%coverage%/coverage.xml ^
  -targetdir:%coverage% ^
  -verbosity:Error