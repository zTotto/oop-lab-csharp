namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        /// <inheritdoc cref="IComplex.Real"/>
        public double Real { get; }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.Real = re;
            this.Imaginary = im;
        }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(Imaginary, Real);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            if (Real == 0 && Imaginary == 0)
            {
                return "0";
            }
            String res = string.Empty;
            if (Real != 0)
            {
                res += Real.ToString();
            }
            if (Imaginary != 0)
            {
                switch (Imaginary)
                {
                    case 1: res += "+i";
                        break;
                    case -1: res += "-i";
                        break;
                    case double n when n > 0: res += $"+{Imaginary}i";
                        break;
                        default: res+= $"{Imaginary}i";
                        break;
                }
            }
            return res;
            
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return Real == other.Real && Imaginary.Equals(other.Imaginary);
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj is Complex C)
            {
                return Equals(C);
            }
            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
