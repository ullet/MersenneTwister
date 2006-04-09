@echo off
cd Source
echo Compiling MersenneTwister.dll
csc -t:library -out:../bin/MersenneTwister.dll -doc:../doc/MersenneTwister.xml MersenneTwisterRandom.cs
cd ../