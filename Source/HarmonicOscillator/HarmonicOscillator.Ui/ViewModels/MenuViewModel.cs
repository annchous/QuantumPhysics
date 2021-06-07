using System.Windows.Controls;
using System.Windows.Input;
using HarmonicOscillator.Ui.Commands;
using HarmonicOscillator.Ui.Views;

namespace HarmonicOscillator.Ui.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            CurrentPage = new HomePage();
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public ICommand HomeCommand => new BaseCommand(args => CurrentPage = new HomePage());
        public ICommand PotentialPitCommand => new BaseCommand(args => CurrentPage = new PotentialPitView());
        public ICommand PotentialEnergyCommand => new BaseCommand(args => CurrentPage = new PotentialEnergyView());
        public ICommand EigenfunctionsCommand => new BaseCommand(args => CurrentPage = new EigenfunctionsView());
    }
}