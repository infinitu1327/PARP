using System;
using System.Numerics;

namespace PARP4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Прогревыч");
            //for (int i = 0; i < 10; i++)
            //{
            //    TryOnBytes();
            //    TryOnShorts();
            //    TryOnInts();
            //    TryOnLongs();
            //    TryOnFloats();
            //    TryOnDoubles();
            //}

            Console.WriteLine(Vector<int>.Count);
            Console.WriteLine(Vector.IsHardwareAccelerated);

            var bytes = Initializer.GetBytes();
            var shorts = Initializer.GetShorts();
            var ints = Initializer.GetInts();
            var longs = Initializer.GetLongs();
            var floats = Initializer.GetFloats();
            var doubles = Initializer.GetDoubles();

            Console.WriteLine("Sum w/o SIMD");
            Console.WriteLine($"On bytes:{Standart.Try(Standart.SumBytes, bytes.Item1, bytes.Item2)}");
            Console.WriteLine($"On shorts:{Standart.Try(Standart.SumShorts, shorts.Item1, shorts.Item2)}");
            Console.WriteLine($"On ints:{Standart.Try(Standart.SumInts, ints.Item1, ints.Item2)}");
            Console.WriteLine($"On longs:{Standart.Try(Standart.SumLongs, longs.Item1, longs.Item2)}");
            Console.WriteLine($"On floats:{Standart.Try(Standart.SumFloats, floats.Item1, floats.Item2)}");
            Console.WriteLine($"On doubles:{Standart.Try(Standart.SumDoubles, doubles.Item1, doubles.Item2)}");
            Console.WriteLine();
            Console.WriteLine("Sum with SIMD");
            Console.WriteLine($"On bytes:{SIMD.Add(bytes.Item1, bytes.Item2)}");
            Console.WriteLine($"On shorts:{SIMD.Add(shorts.Item1, shorts.Item2)}");
            Console.WriteLine($"On ints:{SIMD.Add(ints.Item1, ints.Item2)}");
            Console.WriteLine($"On longs:{SIMD.Add(longs.Item1, longs.Item2)}");
            Console.WriteLine($"On floats:{SIMD.Add(floats.Item1, floats.Item2)}");
            Console.WriteLine($"On doubles:{SIMD.Add(doubles.Item1, doubles.Item2)}");
            Console.WriteLine();
            Console.WriteLine("Sqrt w/o SIMD");
            Console.WriteLine($"On floats:{Standart.TrySqrt(Standart.SqrtFloats, floats.Item1)}");
            Console.WriteLine($"On doubles:{Standart.TrySqrt(Standart.SqrtDoubles, doubles.Item1)}");
            Console.WriteLine("Sqrt with SIMD");
            Console.WriteLine($"On floats:{SIMD.Sqrt(floats.Item1)}");
            Console.WriteLine($"On doubles:{SIMD.Sqrt(doubles.Item1)}");
            Console.WriteLine();
            var complexs = Initializer.GetComplex();
            Console.WriteLine(
                $"Complex w/o SIMD:{Standart.Try(Standart.MultComplex, complexs.Item1, complexs.Item2)}");
            Console.WriteLine($"Complex with SIMD:{SIMD.MultComplex(complexs.Item1, complexs.Item2)}");
        }
    }
}