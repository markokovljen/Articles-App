using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.ViewModels
{
    public class AddUserViewModel : ViewModelBase
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private bool isAdministrator;
        public bool IsAdministrator
        {
            get
            {
                return isAdministrator;
            }
            set
            {
                isAdministrator = value;
                OnPropertyChanged(nameof(IsAdministrator));
            }
        }

        private string warning;
        public string Warning
        {
            get
            {
                return warning;
            }
            set
            {
                warning = value;
                OnPropertyChanged(nameof(Warning));
            }
        }


        public ICommand AddUserCommand { get; set; }

        public AddUserViewModel(IAddUserService addUserService)
        {
            AddUserCommand = new AddUserCommand(addUserService,this);
        }

    }
}
