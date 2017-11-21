using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace PARP4
{
    class Standart
    {
        public static long Try<T>(Action<T[], T[]> action, T[] arr1, T[] arr2)
        {
            var sw = new Stopwatch();

            sw.Start();
            action(arr1, arr2);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static void SumBytes(byte[] arr1, byte[] arr2)
        {
            var res = new int[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] + arr2[2];
            }
        }

        public static void SumShorts(short[] arr1, short[] arr2)
        {
            var res = new int[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] + arr2[i];
            }
        }

        public static void SumInts(int[] arr1, int[] arr2)
        {
            var res = new int[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] + arr2[i];
            }
        }

        public static void SumLongs(long[] arr1, long[] arr2)
        {
            var res = new long[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] + arr2[i];
            }
        }

        public static void SumFloats(float[] arr1, float[] arr2)
        {
            var res = new float[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] + arr2[i];
            }
        }

        public static void SumDoubles(double[] arr1, double[] arr2)
        {
            var res = new double[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] + arr2[i];
            }
        }

        public static long TrySqrt<T>(Action<T[]> action, T[] arr)
        {
            var sw = new Stopwatch();

            sw.Start();
            action(arr);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static void SqrtFloats(float[] arr)
        {
            var res = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = Math.Sqrt(arr[i]);
            }
        }

        public static void SqrtDoubles(double[] arr)
        {
            var res = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = Math.Sqrt(arr[i]);
            }
        }

        public static void MultComplex(Complex[] arr1, Complex[] arr2)
        {
            var res = new Complex[arr1.Length];

            for (int i = 0; i < arr2.Length; i++)
            {
                res[i] = arr1[i] * arr2[i];
            }
        }
    }

    class SIMD
    {
        public static long Add<T>(T[] arr1, T[] arr2) where T : struct
        {
            var simdLength = Vector<T>.Count;

            var sw = new Stopwatch();
            sw.Start();
            var result = new T[arr1.Length];
            for (int i = 0; i < arr1.Length - simdLength; i += simdLength)
            {
                var va = new Vector<T>(arr1, i);
                var vb = new Vector<T>(arr2, i);

                (va + vb).CopyTo(result, i);
            }
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static long Sqrt<T>(T[] arr) where T : struct
        {
            var simdLength = Vector<T>.Count;

            var sw = new Stopwatch();
            sw.Start();
            var result = new T[arr.Length];
            for (int i = 0; i < arr.Length - simdLength; i += simdLength)
            {
                var va = new Vector<T>(arr, i);
                Vector.SquareRoot(va).CopyTo(result, i);
            }
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static long MultComplex(float[] realFirst, float[] imaginaryFirst, float[] realSecond, float[] imaginarySecond)
        {
            var simdLength = Vector<float>.Count;

            var realRes = new float[realFirst.Length];
            var imaginaryRes = new float[realFirst.Length];

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < realFirst.Length - simdLength; i += simdLength)
            {
                var realFirstVector = new Vector<float>(realFirst, i);
                var imaginaryFirstVector = new Vector<float>(imaginaryFirst, i);
                var realSecondVector = new Vector<float>(realSecond, i);
                var imaginarySecondVector = new Vector<float>(imaginarySecond, i);

                (realFirstVector * imaginaryFirstVector -
                 imaginaryFirstVector * imaginarySecondVector).CopyTo(realRes, i);
                (realFirstVector * imaginarySecondVector +
                 imaginaryFirstVector * realSecondVector).CopyTo(imaginaryRes, i);
            }

            sw.Stop();

            var complexRes = new Complex[realRes.Length];

            for (int i = 0; i < realRes.Length; i++)
            {
                complexRes[i] = new Complex(realRes[i], imaginaryRes[i]);
            }

            return sw.ElapsedMilliseconds;
        }
    }

    class Initializer
    {
        public static Tuple<byte[], byte[]> GetBytes()
        {
            var random = new Random();
            var arr1 = new byte[4096 * 4096];
            var arr2 = new byte[4096 * 4096];
            random.NextBytes(arr1);
            random.NextBytes(arr2);

            return new Tuple<byte[], byte[]>(arr1, arr2);
        }

        public static Tuple<short[], short[]> GetShorts()
        {
            var random = new Random();
            var arr1 = new short[4096 * 4096];
            var arr2 = new short[4096 * 4096];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = (short)random.Next(short.MinValue, short.MaxValue);
                arr2[i] = (short)random.Next(short.MinValue, short.MaxValue);
            }

            return new Tuple<short[], short[]>(arr1, arr2);
        }

        public static Tuple<int[], int[]> GetInts()
        {

            var random = new Random();
            var arr1 = new int[4096 * 4096];
            var arr2 = new int[4096 * 4096];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next();
                arr2[i] = random.Next();
            }

            return new Tuple<int[], int[]>(arr1, arr2);
        }

        public static Tuple<long[], long[]> GetLongs()
        {
            var random = new Random();
            var arr1 = new long[4096 * 4096];
            var arr2 = new long[4096 * 4096];
            for (int i = 0; i < 4096 * 4096; i++)
            {
                var num = new byte[8];
                random.NextBytes(num);
                arr1[i] = BitConverter.ToInt64(num, 0);

                random.NextBytes(num);
                arr2[i] = BitConverter.ToInt64(num, 0);
            }

            return new Tuple<long[], long[]>(arr1, arr2);
        }

        public static Tuple<float[], float[]> GetFloats()
        {
            var random = new Random();
            var arr1 = new float[4096 * 4096];
            var arr2 = new float[4096 * 4096];
            for (int i = 0; i < 4096 * 4096; i++)
            {
                var num = new byte[4];
                random.NextBytes(num);
                arr1[i] = BitConverter.ToSingle(num, 0);

                random.NextBytes(num);
                arr2[i] = BitConverter.ToSingle(num, 0);
            }

            return new Tuple<float[], float[]>(arr1, arr2);
        }

        public static Tuple<double[], double[]> GetDoubles()
        {
            var random = new Random();
            var arr1 = new double[4096 * 4096];
            var arr2 = new double[4096 * 4096];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.NextDouble();
                arr2[i] = random.NextDouble();
            }

            return new Tuple<double[], double[]>(arr1, arr2);
        }

        //public static Tuple<Complex[], Complex[]> GetComplex()
        //{
        //    var floats = GetFloats();
        //    var arr1 = new Complex[floats.Item1.Length];

        //    for (int i = 0; i < floats.Item1.Length; i++)
        //    {
        //        arr1[i] = new Complex(floats.Item1[i], floats.Item2[i]);
        //    }

        //    floats = GetFloats();
        //    var arr2 = new Complex[floats.Item1.Length];

        //    for (int i = 0; i < floats.Item1.Length; i++)
        //    {
        //        arr2[i] = new Complex(floats.Item1[i], floats.Item2[i]);
        //    }
        //    return new Tuple<Complex[], Complex[]>(arr1, arr2);
        //}
    }

    class Program
    {
        static void Main(string[] args)
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
            //var complex = Initializer.GetComplex();
            var floats2 = Initializer.GetFloats();

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
            Console.WriteLine(
                $"Complex w/o SIMD:{Standart.Try(Standart.MultComplex, floats.Item1.Select((el, i) => new Complex(el, floats.Item2[i])).ToArray(), floats2.Item1.Select((el, i) => new Complex(el, floats2.Item2[i])).ToArray())}");
            Console.WriteLine($"Complex with SIMD:{SIMD.MultComplex(floats.Item1, floats.Item2, floats2.Item1, floats2.Item2)}");
        }
    }
}
