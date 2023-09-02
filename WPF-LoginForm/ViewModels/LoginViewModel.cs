using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;

namespace WPF_LoginForm.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields 
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        //Properties 
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {

                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // -> Commands 
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommnad { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RemmemberPasswordCommnad { get; }

        // Constructor 
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExcuteLoginCommand, CanExcuteLoginCommand);
            RecoverPasswordCommnad = new ViewModelCommand(p => ExcuteRecoverPassCommnad("",""));

        }

        private void ExcuteRecoverPassCommnad(string username , string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExcuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExcuteLoginCommand(object obj)
        {
            
        }
    }
}
