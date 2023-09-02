using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPF_LoginForm.Repositories;
using WPF_LoginForm.ViewModels;

namespace WPF_LoginForm.Models
{
    public class MainViewModel : ViewModelBase
    {
        //Fields 
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if( user != null )
            {
                CurrentUserAccount = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"Welcome {user.Name} {user.LastName} ;)",
                    ProfilePicture = null
                };
            }
            else
            {
                MessageBox.Show("Invalid user , not logged in");
                Application.Current.Shutdown();
            }
        }
    }
}
