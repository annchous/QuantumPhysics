using System;
using MathNet.Numerics;

namespace HarmonicOscillator
{
    public class Eigenfunction
    {
        public Int32 N { get; set; }
        public Double ParticleMass { get; }
        public Double OscillatorFrequency { get; }
        public HermitePolynomial HermitePolynomial { get; }

        public const Double PlanckConstant = 1.0545726e-34;

        public Eigenfunction(Int32 n, Double particleMass, Double oscillatorFrequency, HermitePolynomial hermitePolynomial)
        {
            N = n;
            ParticleMass = particleMass;
            OscillatorFrequency = oscillatorFrequency;
            HermitePolynomial = hermitePolynomial;
        }

        public Double GetValue(Double x) =>
            Math.Pow((ParticleMass * OscillatorFrequency) / (PlanckConstant * Math.PI), 0.25) *
            (1 / (Math.Sqrt(Math.Pow(2, N) * SpecialFunctions.Factorial(N)))) *
            HermitePolynomial.GetPolynomialValue(x) * Math.Pow(Math.E,
                (-ParticleMass * OscillatorFrequency * Math.Pow(x, 2)) / (2 * PlanckConstant));
    }
}