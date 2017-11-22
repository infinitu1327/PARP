namespace PARP4
{
    internal class FloatComplex
    {
        public FloatComplex()
        {
        }

        public FloatComplex(float real, float imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public float Real { get; set; }
        public float Imaginary { get; set; }
    }
}