namespace PARP3
{
    internal struct FloatComplex
    {
        public FloatComplex(float real, float imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public float Real { get; set; }
        public float Imaginary { get; set; }
    }
}