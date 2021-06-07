using System;
using MathNet.Numerics;

namespace HarmonicOscillator
{
    public class WaveFunction
    {
        public Int32 N { get; }
        public HermitePolynomial HermitePolynomial { get; }

        public WaveFunction(Int32 n, HermitePolynomial hermitePolynomial)
        {
            N = n;
            HermitePolynomial = hermitePolynomial;
        }

        public Double Coefficient =>
            Math.Sqrt(1 / (SpecialFunctions.Factorial(N) * Math.Pow(2, N) * Math.Sqrt(Math.PI)));

        public Double GetValue(Double x) => Coefficient * HermitePolynomial.GetPolynomialValue(x);
    }
}