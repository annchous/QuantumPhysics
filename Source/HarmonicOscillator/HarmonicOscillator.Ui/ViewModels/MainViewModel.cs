using System.Windows.Controls;
using System.Windows.Input;
using HarmonicOscillator.Ui.Commands;
using HarmonicOscillator.Ui.Views;

namespace HarmonicOscillator.Ui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand NavigationCommand { get; }

        public MainViewModel()
        {
            CurrentPage = new PotentialEnergyView();
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            private set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }
}