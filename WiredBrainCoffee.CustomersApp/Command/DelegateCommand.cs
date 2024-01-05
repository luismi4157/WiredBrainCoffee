using System;
using System.Windows.Input;

namespace WiredBrainCoffee.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _excecute;
        private readonly Func<object?, bool>? _canExecute;

        public DelegateCommand(Action<object?> excecute, Func<object?, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(excecute);
            _excecute = excecute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);

        public void Execute(object? parameter) => _excecute(parameter);
    }
}
