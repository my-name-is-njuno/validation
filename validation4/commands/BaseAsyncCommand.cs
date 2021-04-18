using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace validation4.commands
{
    public abstract class BaseAsyncCommand : ICommand
    {
        private bool _isExcuting;

        public bool IsExecuting
        {
            get { return _isExcuting; }
            set { _isExcuting = value; OnCanExcuteChanged(); }
        }

        protected void OnCanExcuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }

        protected abstract Task ExecuteAsync(object parameter);
    }
}
