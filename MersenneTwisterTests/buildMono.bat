@echo off
REM : Before running this script make sure that the MersenneTwister.dll 
REM : assembly is in the bin folder and nunit.rsp contains the correct
REM : path of the nunit.framework.dll assembly.
cd Source
echo Compiling MersenneTwisterTests.dll
call mcs @nunitWinMono.rsp -t:library -out:../bin/MersenneTwisterTests.dll -lib:../bin/ -r:MersenneTwister.dll MersenneTwisterRandomTests.cs
cd ../
echo Running tests
nunit-console.bat bin/MersenneTwisterTests.dll
