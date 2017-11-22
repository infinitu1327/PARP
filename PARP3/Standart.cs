using System;
using System.Diagnostics;

namespace PARP4
{
    internal class Standart
    {
        public static long Try<T>(Action<T[], T[]> action, T[] first, T[] second)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            action(first, second);
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static void SumBytes(byte[] first, byte[] second)
        {
            var result = new int[first.Length];

            for (var i = 0; i < second.Length; i++)
                result[i] = first[i] + second[2];
        }

        public static void SumShorts(short[] first, short[] second)
        {
            var result = new int[first.Length];

            for (var i = 0; i < second.Length; i++)
                result[i] = first[i] + second[i];
        }

        public static void SumInts(int[] first, int[] second)
        {
            var result = new int[first.Length];

            for (var i = 0; i < second.Length; i++)
                result[i] = first[i] + second[i];
        }

        public static void SumLongs(long[] first, long[] second)
        {
            var result = new long[first.Length];

            for (var i = 0; i < second.Length; i++)
                result[i] = first[i] + second[i];
        }

        public static void SumFloats(float[] first, float[] second)
        {
            var result = new float[first.Length];

            for (var i = 0; i < second.Length; i++)
                result[i] = first[i] + second[i];
        }

        public static void SumDoubles(double[] first, double[] second)
        {
            var result = new double[first.Length];

            for (var i = 0; i < second.Length; i++)
                result[i] = first[i] + second[i];
        }

        public static long TrySqrt<T>(Action<T[]> action, T[] arr)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            action(arr);
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static void SqrtFloats(float[] array)
        {
            var result = new double[array.Length];

            for (var i = 0; i < array.Length; i++)
                result[i] = Math.Sqrt(array[i]);
        }

        public static void SqrtDoubles(double[] array)
        {
            var result = new double[array.Length];

            for (var i = 0; i < array.Length; i++)
                result[i] = Math.Sqrt(array[i]);
        }

        public static void MultComplex(FloatComplex[] first, FloatComplex[] second)
        {
            var result = new FloatComplex[first.Length];

            for (var i = 0; i < first.Length; i++)
                result[i] = new FloatComplex
                {
                    Real = first[i].Real * second[i].Real - first[i].Imaginary * second[i].Imaginary,
                    Imaginary = first[i].Imaginary * second[i].Real + second[i].Imaginary * first[i].Real
                };
        }
    }
}