using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotifyAppBase
{
    public class RelayCommand : ICommand
    {
        private Action ExecuteMethod;
        private Func<bool> CanExecuteMethod;
        public RelayCommand(Action execute)
        {
            this.ExecuteMethod = execute;
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.ExecuteMethod = execute;
            this.CanExecuteMethod = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //根据自己需要更改
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.CanExecuteMethod == null)
            {
                this.ExecuteMethod?.Invoke();
            }
            else
            {
                var canexecute = this.CanExecuteMethod.Invoke();
                if (canexecute == true)
                {
                    this.ExecuteMethod?.Invoke();
                }
            }
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private Action<T> ExecuteMethod;
        private Func<T, bool> CanExecuteMethod;
        public RelayCommand(Action<T> execute)
        {
            this.ExecuteMethod = execute;
        }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.ExecuteMethod = execute;
            this.CanExecuteMethod = canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //根据自己需要更改
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.CanExecuteMethod == null)
            {
                this.ExecuteMethod?.Invoke((T)parameter);
            }
            else
            {
                var canexecute = this.CanExecuteMethod?.Invoke((T)parameter);
                if (canexecute == true)
                {
                    this.ExecuteMethod?.Invoke((T)parameter);
                }
            }
        }
    }
}
