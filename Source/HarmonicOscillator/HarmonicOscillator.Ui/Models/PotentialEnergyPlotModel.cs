namespace HarmonicOscillator.Ui.Models
{
    public class PotentialEnergyPlotModel
    {
        private readonly Eigenvalue _eigenvalue;
        private readonly PotentialEnergy _potentialEnergy;

        public PotentialEnergyPlotModel(Eigenvalue eigenvalue, PotentialEnergy potentialEnergy)
        {
            _eigenvalue = eigenvalue;
            _potentialEnergy = potentialEnergy;
        }
    }
}