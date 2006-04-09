/* 
   An C#.NET implementation of the Mersenne Twister pseudorandom number
   generator (MT19937).
   This .NET implementation modified February 2006 by Trevor Barnett from 
   the original C code coded by Makoto Matsumoto and Takuji Nishimura.
   See http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html for further
   information and for the original C code.

   Please send any comments, questions, etc regarding this implementation
   to Trevor Barnett, swst@e381.net
   
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
   A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
   LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
   NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;

namespace Utilities
{
    /// <summary>
    /// Random number generator using Mersenne Twister algorithm
    /// </summary>
    /// <remarks>
    /// Inherits from System.Random
    /// </remarks>
    public class MersenneTwisterRandom : System.Random
    {
        private UInt32[] _stateVector;
        private const int _stateVectorSize = 624;
        private const int _valueM = 397;
        private const UInt32 _upperMask = 0x80000000; // most significant w-r bits
        private const UInt32 _lowerMask = 0x7fffffff; // least significant r bits
        private UInt32[] mag01 = new UInt32[]{0, 0x9908b0df}; // used in generating next random number
        private int nextValueIndex;

        /// <summary>
        /// Initializes a new instance of the MersenneTwisterRandom class, 
        /// using a time-dependent default seed value.
        /// </summary>
        public MersenneTwisterRandom()
        {     
            initialise((UInt32)(System.DateTime.Now.Ticks & 0xFFFFFFFF));
        }

        /// <summary>
        /// Initializes a new instance of the MersenneTwisterRandom class, 
        /// using the specified seed value.
        /// </summary>
        /// <param name="seed">
        /// A number used to calculate a starting value for the pseudo-random number sequence.
        /// </param>
        public MersenneTwisterRandom(int seed)
        {
            initialise((UInt32)seed);
        }

        /// <summary>
        /// Initialise the random number generator, using the specified seed value.
        /// </summary>
        /// <param name="seed">
        /// A number used to calculate a starting value for the pseudo-random number sequence.
        /// </param>
        private void initialise(UInt32 seed)
        {
            const UInt32 multiplier = 1812433253;
            _stateVector = new UInt32[_stateVectorSize];
            _stateVector[0] = seed;
            for (int index=1; index<_stateVectorSize; index++) 
            {
                _stateVector[index] = 
                    (multiplier * (_stateVector[index-1] ^ (_stateVector[index-1] >> 30)) + (UInt32)index);
            }
            nextValueIndex = _stateVectorSize;
        }

        /// <summary>
        /// Returns a nonnegative random number.
        /// </summary>
        /// <returns>
        /// A non-negative random integer between 0 and 2147483646.
        /// </returns>
        // Appears need to override Next even if overriding Sample as
        // doesn't appear to use overridden Sample method, at least not in
        // a way which I understand.
        public override int Next()
        {
            // convert down to signed int
            return (int)(GenerateRandomValue() & 0x7FFFFFFF);
        }

        /// <summary>
        /// Returns a nonnegative random number less than the specified 
        /// maximum.
        /// </summary>
        /// <param name="maxValue">
        /// The upper bound of the random number to be generated. 
        /// maxValue must be greater than or equal to zero.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer greater than or equal to zero, and
        /// less than maxValue; that is, the range of return values 
        /// includes zero but not MaxValue.
        /// </returns>
        // Explicitly override so intellisense displays this type!
        public override int Next(int maxValue)
        {
            return base.Next(maxValue);
        }

        /// <summary>
        /// Returns a random number within a specified range.
        /// </summary>
        /// <param name="minValue">
        /// The lower bound of the random number returned.
        /// </param>
        /// <param name="maxValue">
        /// The upper bound of the random number returned. maxValue must 
        /// be greater than or equal to minValue.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer greater than or equal to minValue and 
        /// less than maxValue; that is, the range of return values 
        /// includes minValue but not MaxValue. If minValue equals 
        /// maxValue, minValue is returned.
        /// </returns>
        /// <remarks>
        /// Overrides base method to ensure negative values rounded in
        /// same way under Mono and Microsoft® .NET Framework.
        /// </remarks>
        public override int Next(int minValue, int maxValue)
        {
            return (int)Math.Floor(
                Sample()*(double)(maxValue-minValue)+(double)minValue);
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>
        /// A double-precision floating point number greater than or 
        /// equal to 0.0, and less than 1.0.
        /// </returns>
        /// <remarks>
        /// This method is the public version of the protected method, 
        /// <see cref="Sample"/>
        /// </remarks>
        public override double NextDouble()
        {
            return base.NextDouble ();
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">
        /// An array of bytes to contain random numbers.
        /// </param>
        // Appears need to override NextBytes even if overriding Sample as
        // doesn't appear to use overridden Sample method, at least not in
        // a way which I understand.
        public override void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                return;
            }

            int bufferLength = buffer.Length;
            int numberValues = (int)((bufferLength+3) / 4);

            int bufferIndex = 0;
            for (int index=0; index<numberValues; index++)
            {
                UInt32 randVal = GenerateRandomValue();
                byte val = (byte)((randVal & 0xFF000000) >> 24);
                buffer[bufferIndex++] = val;
                if (bufferIndex > bufferLength) break;
                val = (byte)((randVal & 0x00FF0000) >> 16);
                buffer[bufferIndex++] = val;
                if (bufferIndex > bufferLength) break;
                val = (byte)((randVal & 0x0000FF00) >> 8);
                buffer[bufferIndex++] = val;
                if (bufferIndex > bufferLength) break;
                val = (byte)(randVal & 0x000000FF);
                buffer[bufferIndex++] = val;
                if (bufferIndex > bufferLength) break;
            }
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>
        /// Random number between 0.0 and 1.0.
        /// </returns>
        protected override double Sample()
        {
            double twoPower32 = 4294967296.0;
            return ((double)GenerateRandomValue()) / twoPower32;
        }

        /// <summary>
        /// Returns a random 32 bit intger between 0 and 4294967295 inclusive.
        /// </summary>
        /// <returns>
        /// Random 32 bit intger between 0 and 4294967295 inclusive.
        /// </returns>
        private UInt32 GenerateRandomValue()
        {
            const UInt32 temperingValue1 = 0x9d2c5680;
            const UInt32 temperingValue2 = 0xefc60000;
            UInt32 randValue;
            UInt32 intermediate;
            
            if (nextValueIndex >= _stateVectorSize)
            {
                int index;
                for (index=0; index<_stateVectorSize - _valueM; index++) 
                {
                    intermediate = (_stateVector[index] & _upperMask) |
                        (_stateVector[index+1] & _lowerMask);
                    _stateVector[index] = 
                        _stateVector[index+_valueM] ^ (intermediate >> 1) ^ 
                        mag01[(int)(intermediate & 1)];
                }
                for (;index<_stateVectorSize-1; index++)
                {
                    intermediate = (_stateVector[index] & _upperMask) |
                        (_stateVector[index+1] & _lowerMask);
                    _stateVector[index] =
                        _stateVector[index+_valueM-_stateVectorSize] ^
                        (intermediate >> 1) ^
                        mag01[(int)(intermediate & 1)];
                }
                intermediate = (_stateVector[_stateVectorSize-1] & _upperMask) |
                    (_stateVector[0] & _lowerMask);
                _stateVector[_stateVectorSize-1] = _stateVector[_valueM-1] ^
                    (intermediate >> 1) ^
                    mag01[(int)(intermediate & 1)];

                nextValueIndex = 0;
            }
            randValue = _stateVector[nextValueIndex++];

            // Tempering 
            randValue ^= (randValue >> 11);
            randValue ^= (randValue << 7) & temperingValue1;
            randValue ^= (randValue << 15) & temperingValue2;
            randValue ^= (randValue >> 18);

            return randValue;
        }
    }
}
