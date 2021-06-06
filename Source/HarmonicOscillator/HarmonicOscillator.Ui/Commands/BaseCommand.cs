using System;
using System.Windows.Input;

namespace HarmonicOscillator.Ui.Commands
{
    public class BaseCommand : ICommand
    {
        private readonly Action<Object> _action;

        public BaseCommand(Action<Object> action)
        {
            _action = action;
        }

        public Boolean CanExecute(Object parameter)
        {
            return true;
        }

        public void Execute(Object parameter)
        {
            _action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}