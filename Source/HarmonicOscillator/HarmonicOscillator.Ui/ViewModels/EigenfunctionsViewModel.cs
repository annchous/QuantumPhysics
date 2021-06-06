using System;
using System.Windows.Input;
using HarmonicOscillator.Ui.Commands;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace HarmonicOscillator.Ui.ViewModels
{
    public class EigenfunctionsViewModel : BaseViewModel
    {
        private PlotModel _plotModel;
        private Int32 _number;
        private Double _particleMass;
        private Double _oscillatorFrequency;

        public Double ParticleMass
        {
            get => _particleMass;
            set
            {
                _particleMass = value;
                OnPropertyChanged();
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

        public Int32 Number
        {
            get => _number;
            set
            {
                _number = value;
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
                    });

                    var eigenfunction = new Eigenfunction(_number, _particleMass, _oscillatorFrequency,
                        new HermitePolynomial(_number));
                    var eigenfunctionSeries = new LineSeries();
                    for (Double x = -5; x < 5; x += 0.1)
                    {
                        eigenfunctionSeries.Points.Add(new DataPoint(x, eigenfunction.GetValue(x)));
                    }
                    plotModel.Series.Add(eigenfunctionSeries);

                    PlotModel = plotModel;
                });
            }
        }
    }
}