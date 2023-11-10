using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_LoginForm.Model;
using WPF_LoginForm.Repositories;


namespace WPF_LoginForm.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;


        //properties
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return CurrentUserAccount1;
            }
            set
            {
                CurrentUserAccount1 = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public UserAccountModel CurrentUserAccount1 
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
            }
        }
        public ViewModelBase CurrentChildView 
        { 
            get
            {
                return _currentChildView;
            }
            set {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));

            }
        }
        public string Caption 
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        
        
        //commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get;  }


        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //initialized commanmds
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            //default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
                
            }
            else
            {
                CurrentUserAccount.DisplayName="Invalid user, not logged in";
                
            }
        }
    }
}
