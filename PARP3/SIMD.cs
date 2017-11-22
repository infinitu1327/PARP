using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;

namespace PARP4
{
    internal class SIMD
    {
        public static long Add<T>(T[] first, T[] second) where T : struct
        {
            var simdLength = Vector<T>.Count;
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = new T[first.Length];
            for (var i = 0; i < first.Length - simdLength; i += simdLength)
            {
                var firstVector = new Vector<T>(first, i);
                var secondVector = new Vector<T>(first, i);

                (firstVector + secondVector).CopyTo(result, i);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static long Sqrt<T>(T[] array) where T : struct
        {
            var simdLength = Vector<T>.Count;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = new T[array.Length];
            for (var i = 0; i < array.Length - simdLength; i += simdLength)
            {
                var va = new Vector<T>(array, i);
                Vector.SquareRoot(va).CopyTo(result, i);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static long MultComplex(FloatComplex[] first, FloatComplex[] second)
        {
            var simdLength = Vector<float>.Count;
            var firstTuple = 
                (Real: first.Select(el => el.Real).ToArray(), 
                Imaginary: first.Select(el => el.Imaginary).ToArray());
            var secondTuple =
                (Real: second.Select(el => el.Real).ToArray(), 
                Imaginary: second.Select(el => el.Imaginary).ToArray());
            var result = (Real: new float[first.Length], Imaginary: new float[first.Length]);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (var i = 0; i < firstTuple.Real.Length - simdLength; i += simdLength)
            {
                var firstVector =
                    (Real: new Vector<float>(firstTuple.Real, i),
                    Imaginary: new Vector<float>(secondTuple.Imaginary, i));
                var secondVector =
                    (Real: new Vector<float>(secondTuple.Real, i),
                    Imaginary: new Vector<float>(secondTuple.Imaginary, i));


                (firstVector.Real * firstVector.Imaginary -
                 firstVector.Imaginary * secondVector.Imaginary).CopyTo(result.Real, i);
                (firstVector.Real * secondVector.Imaginary +
                 firstVector.Imaginary * secondVector.Real).CopyTo(result.Imaginary, i);
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}