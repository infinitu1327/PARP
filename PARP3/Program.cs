using System;
using System.Numerics;

namespace PARP3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region GetData

            Console.WriteLine($"Width of the SIMD register file:{Vector<int>.Count * 32}");
            Console.WriteLine($"Is hardware accelerated:{Vector.IsHardwareAccelerated}");
            Console.WriteLine();

            #endregion

            #region Initialization

            var bytes = Initializer.GetBytes();
            var shorts = Initializer.GetShorts();
            var ints = Initializer.GetInts();
            var longs = Initializer.GetLongs();
            var floats = Initializer.GetFloats();
            var doubles = Initializer.GetDoubles();

            #endregion

            #region Task2

            Console.WriteLine("Sum w/o SIMD");
            Console.WriteLine($"On bytes:{Standart.Try(Standart.SumBytes, bytes.Item1, bytes.Item2)}");
            Console.WriteLine($"On shorts:{Standart.Try(Standart.SumShorts, shorts.Item1, shorts.Item2)}");
            Console.WriteLine($"On ints:{Standart.Try(Standart.SumInts, ints.Item1, ints.Item2)}");
            Console.WriteLine($"On longs:{Standart.Try(Standart.SumLongs, longs.Item1, longs.Item2)}");
            Console.WriteLine($"On floats:{Standart.Try(Standart.SumFloats, floats.Item1, floats.Item2)}");
            Console.WriteLine($"On doubles:{Standart.Try(Standart.SumDoubles, doubles.Item1, doubles.Item2)}");
            Console.WriteLine();
            Console.WriteLine("Sum with SIMD");
            Console.WriteLine($"On bytes:{Simd.Add(bytes.Item1, bytes.Item2)}");
            Console.WriteLine($"On shorts:{Simd.Add(shorts.Item1, shorts.Item2)}");
            Console.WriteLine($"On ints:{Simd.Add(ints.Item1, ints.Item2)}");
            Console.WriteLine($"On longs:{Simd.Add(longs.Item1, longs.Item2)}");
            Console.WriteLine($"On floats:{Simd.Add(floats.Item1, floats.Item2)}");
            Console.WriteLine($"On doubles:{Simd.Add(doubles.Item1, doubles.Item2)}");
            Console.WriteLine();

            #endregion


            #region Task6

            Console.WriteLine("Sqrt w/o SIMD");
            Console.WriteLine($"On floats:{Standart.TrySqrt(Standart.SqrtFloats, floats.Item1)}");
            Console.WriteLine($"On doubles:{Standart.TrySqrt(Standart.SqrtDoubles, doubles.Item1)}");
            Console.WriteLine("Sqrt with SIMD");
            Console.WriteLine($"On floats:{Simd.Sqrt(floats.Item1)}");
            Console.WriteLine($"On doubles:{Simd.Sqrt(doubles.Item1)}");
            Console.WriteLine();

            #endregion

            #region Task8

            var complexs = Initializer.GetComplex();
            Console.WriteLine(
                $"Complex w/o SIMD:{Standart.Try(Standart.MultComplex, complexs.Item1, complexs.Item2)}");
            Console.WriteLine($"Complex with SIMD:{Simd.MultComplex(complexs.Item1, complexs.Item2)}");

            #endregion
        }
    }
}