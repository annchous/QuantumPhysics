using System;

namespace HarmonicOscillator
{
    public class PotentialEnergy
    {
        public Double ParticleMass { get; }
        public Double OscillatorFrequency { get; }

        public PotentialEnergy(Double particleMass, Double oscillatorFrequency)
        {
            ParticleMass = particleMass;
            OscillatorFrequency = oscillatorFrequency;
        }

        public Double GetValue(Double x) => ParticleMass * Math.Pow(OscillatorFrequency, 2) * Math.Pow(x, 2) / 2;
    }
}