using System;

namespace HarmonicOscillator
{
    public class Eigenvalue
    {
        public Double OscillatorFrequency { get; }

        public const Double PlanckConstant = 1.0545726e-34;

        public Eigenvalue(Double oscillatorFrequency)
        {
            OscillatorFrequency = oscillatorFrequency;
        }

        public Double GetValue(Int32 n) => PlanckConstant * OscillatorFrequency * (n + 0.5);
    }
}