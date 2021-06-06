using System;

namespace HarmonicOscillator
{
    public class PotentialPit
    {
        public Double Width { get; }
        public Double PotentialEnergy { get; }

        public PotentialPit(Double width, Double potentialEnergy)
        {
            Width = width;
            PotentialEnergy = potentialEnergy;
        }

        public Double GetValue(Double x) => Math.Abs(x) <= Width ? -1 * PotentialEnergy : 0;
    }
}