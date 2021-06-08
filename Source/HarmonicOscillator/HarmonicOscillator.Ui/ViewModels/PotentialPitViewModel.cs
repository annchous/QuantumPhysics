using System;
using System.Windows.Input;
using HarmonicOscillator.Ui.Commands;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace HarmonicOscillator.Ui.ViewModels
{
    public class PotentialPitViewModel : BaseViewModel
    {
        private PlotModel _plotModel;
        private Double _potentialEnergy;
        private Double _potentialPitWidth;

        public Double PotentialEnergy
        {
            get => _potentialEnergy;
            set
            {
                _potentialEnergy = value;
                OnPropertyChanged();
            }
        }

        public Double PotentialPitWidth
        {
            get => _potentialPitWidth;
            set
            {
                _potentialPitWidth = value;
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
                        Title = "Potential pit"
                    };

                    plotModel.Axes.Add(new LinearColorAxis
                    {
                        Palette = OxyPalettes.Jet(1024),
                    });

                    var potentialPit = new PotentialPit(_potentialPitWidth, _potentialEnergy);
                    var potentialPitSeries = new LineSeries();
                    for (Double x = -5; x < 5; x += 0.1)
                    {
                        potentialPitSeries.Points.Add(new DataPoint(x, potentialPit.GetValue(x)));
                    }
                    plotModel.Series.Add(potentialPitSeries);

                    PlotModel = plotModel;
                });
            }
        }
    }
}