using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace PARP4
{
    internal class SIMD
    {
        public static long Add<T>(T[] arr1, T[] arr2) where T : struct
        {
            var simdLength = Vector<T>.Count;

            var sw = new Stopwatch();
            sw.Start();
            var result = new T[arr1.Length];
            for (var i = 0; i < arr1.Length - simdLength; i += simdLength)
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
            for (var i = 0; i < arr.Length - simdLength; i += simdLength)
            {
                var va = new Vector<T>(arr, i);
                Vector.SquareRoot(va).CopyTo(result, i);
            }
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static long MultComplex(FloatComplex[] arr1, FloatComplex[] arr2)
        {
            var simdLength = Vector<float>.Count;
            var length = arr1.Length;
            var realFirst = arr1.Select(el => el.Real).ToArray();
            var imaginaryFirst = arr1.Select(el => el.Imaginary).ToArray();
            var realSecond = arr2.Select(el => el.Real).ToArray();
            var imaginarySecond = arr2.Select(el => el.Imaginary).ToArray();
            var realRes = new float[length];
            var imaginaryRes = new float[length];

            var sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < realFirst.Length - simdLength; i += simdLength)
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

            return sw.ElapsedMilliseconds;
        }
    }
}