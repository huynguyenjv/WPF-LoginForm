using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_LoginForm.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        //Field 
        private readonly Action<object> _excuteAction;
        private readonly Predicate<object> _canExcuteAction;

        //Constructor 
        public ViewModelCommand(Action<object> excuteAction)
        {
            _excuteAction = excuteAction;
            _canExcuteAction = null;
        }

        public ViewModelCommand(Action<object> excuteAction , Predicate<object> canExcuteAction) 
        {
            _excuteAction = excuteAction;
            _canExcuteAction = canExcuteAction;
        }

        public event EventHandler? CanExecuteChanged;


        // Event 
        public event EventHandler CanExcuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }
        
        public bool CanExcute(object parameter)
        {
           return _canExcuteAction == null ? true : _canExcuteAction(parameter); 
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Excute(object parameter)
        {
            _excuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
