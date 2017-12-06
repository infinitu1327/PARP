using System;

namespace PARP3
{
    internal static class Initializer
    {
        private const long Length = 4096 * 4096;
        private static readonly Random Random = new Random();

        public static (byte[], byte[]) GetBytes()
        {
            var first = new byte[Length];
            var second = new byte[Length];
            Random.NextBytes(first);
            Random.NextBytes(second);

            return (first, second);
        }

        public static (short[], short[]) GetShorts()
        {
            var first = new short[Length];
            var second = new short[Length];

            for (var i = 0; i < Length; i++)
            {
                first[i] = (short) Random.Next(short.MinValue, short.MaxValue);
                second[i] = (short) Random.Next(short.MinValue, short.MaxValue);
            }

            return (first, second);
        }

        public static (int[], int[]) GetInts()
        {
            var first = new int[Length];
            var second = new int[Length];

            for (var i = 0; i < Length; i++)
            {
                first[i] = Random.Next();
                second[i] = Random.Next();
            }

            return (first, second);
        }

        public static (long[], long[]) GetLongs()
        {
            var first = new long[Length];
            var second = new long[Length];
            for (var i = 0; i < Length; i++)
            {
                var num = new byte[8];
                Random.NextBytes(num);
                first[i] = BitConverter.ToInt64(num, 0);

                Random.NextBytes(num);
                second[i] = BitConverter.ToInt64(num, 0);
            }

            return (first, second);
        }

        public static (float[], float[]) GetFloats()
        {
            var first = new float[Length];
            var second = new float[Length];
            for (var i = 0; i < Length; i++)
            {
                var num = new byte[4];
                Random.NextBytes(num);
                first[i] = BitConverter.ToSingle(num, 0);

                Random.NextBytes(num);
                second[i] = BitConverter.ToSingle(num, 0);
            }

            return (first, second);
        }

        public static (double[], double[]) GetDoubles()
        {
            var first = new double[Length];
            var second = new double[Length];

            for (var i = 0; i < Length; i++)
            {
                first[i] = Random.NextDouble();
                second[i] = Random.NextDouble();
            }

            return (first, second);
        }

        public static (FloatComplex[], FloatComplex[]) GetComplex()
        {
            var floats = GetFloats();
            var first = new FloatComplex[Length];

            for (var i = 0; i < Length; i++)
                first[i] = new FloatComplex(floats.Item1[i], floats.Item2[i]);

            floats = GetFloats();
            var second = new FloatComplex[Length];

            for (var i = 0; i < Length; i++)
                second[i] = new FloatComplex(floats.Item1[i], floats.Item2[i]);
            return (first, second);
        }
    }
}