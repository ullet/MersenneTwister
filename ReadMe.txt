Mersenne Twister - a pseudorandom number generator
==================================================

Mersenne Twister is a pseudorandom number generating algorithm developed by
Makoto Matsumoto and Takuji Nishimura in 1996/1997.  It is designed for 
fast generation of high quality pseudorandom numbers.  Please note that
this algorithm as provided here is not suitable for cryptography.
For further information see 
http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html

Please send any comments, questions, etc with regard to this distribution
and implementation of the algorithm to Trevor Barnett, swst@e381.net

If you have any comments, questions, etc with regard to the original 
Mersenne Twister algorithm please see 
http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html


Files
-----

This distribution contains the following 14 files:

ReadMe.txt
- this document
MersenneTwister/build
- simple bash shell script to build assembly
MersenneTwister/build.bat
- simple DOS batch file to build assembly using Microsoft(R) .NET csc 
  compiler
MersenneTwister/buildMono.bat
- simple DOS batch file to build assembly using Mono mcs compiler
MersenneTwister/Source/MersenneTwisterRandom.cs
- the pseduorandom number generator class
MersenneTwister/Source/AssemblyInfo.cs
- standard .NET assembly version information for above
MersenneTwisterTests/build
- simple bash shell script to build test assembly
MersenneTwisterTests/build.bat
- simple DOS batch file to build assembly using Microsoft(R) .NET csc 
  compiler
MersenneTwisterTests/buildMono.bat
- simple DOS batch file to build assembly using Mono mcs compiler
MersenneTwisterTests/MersenneTwisterRandomTests.cs 
- NUnit based unit tests for the generator class
MersenneTwisterTests/Source/AssemblyInfo.cs
- standard .NET assembly version information for above
MersenneTwisterTests/Source/nunit.rsp
- response file containing path to nunit.framework.dll for standard 
  installation on linux using mono-1.1.13.2_0-installer.bin
MersenneTwisterTests/Source/nunitWin.rsp
- response file containing path to nunit.framework.dll for standard
  installation on Windows of NUnit 2.2.5
MersenneTwisterTests/Source/nunitWinMono.rsp
- response file containing path to nunit.framework.dll for standard
  installation on Windows of Mono 1.1.13
                    
It is not required that the unit test source be distributed with the main
class source but if the unit test source is not included then this document
must be modified appropriately.


Copyright and License
---------------------

Copyright (C) 1997 - 2002, Makoto Matsumoto and Takuji Nishimura,
All rights reserved.                            
Copyright (C) 2006  Trevor Barnett

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

  1. Redistributions of source code must retain the above copyright
     notice, this list of conditions and the following disclaimer.

  2. Redistributions in binary form must reproduce the above copyright
     notice, this list of conditions and the following disclaimer in the
     documentation and/or other materials provided with the distribution.

  3. The names of its contributors may not be used to endorse or promote 
     products derived from this software without specific prior written 
     permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER
OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
