using System;
using System.Diagnostics;

namespace PARP4
{
    internal class Standart
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

            for (var i = 0; i < arr2.Length; i++)
                res[i] = arr1[i] + arr2[2];
        }

        public static void SumShorts(short[] arr1, short[] arr2)
        {
            var res = new int[arr1.Length];

            for (var i = 0; i < arr2.Length; i++)
                res[i] = arr1[i] + arr2[i];
        }

        public static void SumInts(int[] arr1, int[] arr2)
        {
            var res = new int[arr1.Length];

            for (var i = 0; i < arr2.Length; i++)
                res[i] = arr1[i] + arr2[i];
        }

        public static void SumLongs(long[] arr1, long[] arr2)
        {
            var res = new long[arr1.Length];

            for (var i = 0; i < arr2.Length; i++)
                res[i] = arr1[i] + arr2[i];
        }

        public static void SumFloats(float[] arr1, float[] arr2)
        {
            var res = new float[arr1.Length];

            for (var i = 0; i < arr2.Length; i++)
                res[i] = arr1[i] + arr2[i];
        }

        public static void SumDoubles(double[] arr1, double[] arr2)
        {
            var res = new double[arr1.Length];

            for (var i = 0; i < arr2.Length; i++)
                res[i] = arr1[i] + arr2[i];
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

            for (var i = 0; i < arr.Length; i++)
                res[i] = Math.Sqrt(arr[i]);
        }

        public static void SqrtDoubles(double[] arr)
        {
            var res = new double[arr.Length];

            for (var i = 0; i < arr.Length; i++)
                res[i] = Math.Sqrt(arr[i]);
        }

        public static void MultComplex(FloatComplex[] arr1, FloatComplex[] arr2)
        {
            var res = MultComplexs(arr1, arr2);
        }

        public static FloatComplex[] MultComplexs(FloatComplex[] first, FloatComplex[] second)
        {
            var res = new FloatComplex[first.Length];

            for (var i = 0; i < first.Length; i++)
                res[i] = new FloatComplex
                {
                    Real = first[i].Real * second[i].Real - first[i].Imaginary * second[i].Imaginary,
                    Imaginary = first[i].Imaginary * second[i].Real + second[i].Imaginary * first[i].Real
                };

            return res;
        }
    }
}