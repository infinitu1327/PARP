using System;

namespace PARP4
{
    internal class Initializer
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

            for (var i = 0; i < arr1.Length; i++)
            {
                arr1[i] = (short) random.Next(short.MinValue, short.MaxValue);
                arr2[i] = (short) random.Next(short.MinValue, short.MaxValue);
            }

            return new Tuple<short[], short[]>(arr1, arr2);
        }

        public static Tuple<int[], int[]> GetInts()
        {
            var random = new Random();
            var arr1 = new int[4096 * 4096];
            var arr2 = new int[4096 * 4096];

            for (var i = 0; i < arr1.Length; i++)
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
            for (var i = 0; i < 4096 * 4096; i++)
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
            for (var i = 0; i < 4096 * 4096; i++)
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

            for (var i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.NextDouble();
                arr2[i] = random.NextDouble();
            }

            return new Tuple<double[], double[]>(arr1, arr2);
        }

        public static Tuple<FloatComplex[], FloatComplex[]> GetComplex()
        {
            var floats = GetFloats();
            var arr1 = new FloatComplex[floats.Item1.Length];

            for (var i = 0; i < floats.Item1.Length; i++)
                arr1[i] = new FloatComplex(floats.Item1[i], floats.Item2[i]);

            floats = GetFloats();
            var arr2 = new FloatComplex[floats.Item1.Length];

            for (var i = 0; i < floats.Item1.Length; i++)
                arr2[i] = new FloatComplex(floats.Item1[i], floats.Item2[i]);
            return new Tuple<FloatComplex[], FloatComplex[]>(arr1, arr2);
        }
    }
}