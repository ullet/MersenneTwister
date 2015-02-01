Mersenne Twister - a pseudorandom number generator
==================================================

Mersenne Twister is a pseudorandom number generating algorithm developed by
Makoto Matsumoto and Takuji Nishimura in 1996/1997.  It is designed for 
fast generation of high quality pseudorandom numbers.  Please note that
this algorithm as provided here is not suitable for cryptography.
For further information see 
http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html

This is a C# implementation of the Mersenne Twister algorithm ported from the original
C source code by Makoto Matsumoto and Takuji Nishimura.  The main algorithm code is almost
a straight copy from the C source code with minor changes to use longer more descriptive
names and for layout and style.

The `MersenneTwisterRandom` class extends `System.Random` so that it can be used as a "drop in"
replacement for `System.Random`.

Files
-----

This distribution contains the following 15 files:

* `README.md` - this document
* `LICENSE` - released under a BSD-style license
* MersenneTwister/
  * `build` - simple bash shell script to build assembly
  * `build.bat` - simple DOS batch file to build assembly using Microsoft<sup>&reg;</sup> .NET csc compiler
  * `buildMono.bat` - simple DOS batch file to build assembly using Mono mcs compiler
  * Source/
    * `MersenneTwisterRandom.cs` - the pseduorandom number generator class
    * `AssemblyInfo.cs` - standard .NET assembly version information for above
* MersenneTwisterTests/
  * `build` - simple bash shell script to build test assembly
  * `build.bat` - simple DOS batch file to build assembly using Microsoft<sup>&reg;</sup> .NET csc compiler
  * `buildMono.bat` - simple DOS batch file to build assembly using Mono mcs compiler
  * Source/
    * `MersenneTwisterRandomTests.cs` - NUnit based unit tests for the generator class
    * `AssemblyInfo.cs` - standard .NET assembly version information for above
    * `nunit.rsp` - response file containing path to nunit.framework.dll for standard installation on 
    linux using mono-1.1.13.2_0-installer.bin
    * `nunitWin.rsp` - response file containing path to nunit.framework.dll for standard installation
    on Windows of NUnit 2.2.5
    * `nunitWinMono.rsp` - response file containing path to nunit.framework.dll for standard installation
    on Windows of Mono 1.1.13
