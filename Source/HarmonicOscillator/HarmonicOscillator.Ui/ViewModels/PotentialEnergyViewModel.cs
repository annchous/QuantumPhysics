using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using HarmonicOscillator.Ui.Commands;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace HarmonicOscillator.Ui.ViewModels
{
    public class PotentialEnergyViewModel : BaseViewModel
    {
        private PlotModel _plotModel;
        private Double _particleMass;
        private Int32 _phononosNumber;
        private Double _oscillatorFrequency;

        public String ParticleMass
        {
            get => _particleMass.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (Double.TryParse(value, out Double particleMass))
                {
                    _particleMass = particleMass;
                    OnPropertyChanged();
                }
            }
        }

        public Double OscillatorFrequency
        {
            get => _oscillatorFrequency;
            set
            {
                _oscillatorFrequency = value;
                OnPropertyChanged();
            }
        }

        public Int32 PhononosNumber
        {
            get => _phononosNumber;
            set
            {
                _phononosNumber = value;
                OnPropertyChanged();
            }
        }

        public PlotModel PlotModel
        {
            get => _plotModel;
            set
            {
                _plotModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand BuildPlot
        {
            get
            {
                return new BaseCommand(args =>
                {
                    PlotModel plotModel = new PlotModel
                    {
                        Title = "Potential energy of harmonic oscillator"
                    };

                    plotModel.Axes.Add(new LinearColorAxis
                    {
                        Palette = OxyPalettes.Jet(1024),
                        Maximum = 1e-34
                    });

                    var eigenvalue = new Eigenvalue(_oscillatorFrequency);
                    LineSeries eigenvalueSeries = new LineSeries {Color = OxyColor.FromRgb(0, 102, 204)};
                    for (Int32 n = 0; n < 5; n++)
                    {
                        Double y = eigenvalue.GetValue(n);
                        eigenvalueSeries.Points.Add(new DataPoint(-1, y));
                        eigenvalueSeries.Points.Add(new DataPoint(1, y));
                        plotModel.Series.Add(eigenvalueSeries);
                        eigenvalueSeries = new LineSeries {Color = OxyColor.FromRgb(0, 102, 204)};
                    }

                    var potentialEnergy = new PotentialEnergy(_particleMass, _oscillatorFrequency);
                    LineSeries potentialEnergySeries = new LineSeries {Color = OxyColor.FromRgb(255, 0, 102)};
                    for (Double x = -0.1; x < 0.1; x += 0.001)
                    {
                        potentialEnergySeries.Points.Add(new DataPoint(x, potentialEnergy.GetValue(x)));
                    }
                    plotModel.Series.Add(potentialEnergySeries);

                    PlotModel = plotModel;
                });
            }
        }
    }
}