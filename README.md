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
