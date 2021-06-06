using System;
using MathNet.Numerics;

namespace HarmonicOscillator
{
    public class HermitePolynomial
    {
        public Int32 N { get; }

        public HermitePolynomial(Int32 n)
        {
            N = n;
        }

        private Func<Double, Double> Evaluated =>
            (Double x) => Math.Pow(-1, N) * Math.Pow(Math.E, Math.Pow(x, 2));
        private Func<Double, Double> Differentiated =>
            Differentiate.DerivativeFunc((Double x) => Math.Pow(Math.E, -Math.Pow(x, 2)), N);

        public Double GetPolynomialValue(Double x) => Evaluated(x) * Differentiated(x);
    }
}