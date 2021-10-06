using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.Commands;
using KlijentskaAplikacija.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.ViewModels
{
    public class ModifyProfileViewModel : ViewModelBase
    {
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

        public ICommand ModifyProfileCommand { get; set; }
        public ModifyProfileViewModel(IAuthenticator authenticator,IModifyProfileService modifyProfileService)
        {
            
            FirstName = authenticator.UserState.CurrentUser.FirstName;
            LastName = authenticator.UserState.CurrentUser.LastName;
            ModifyProfileCommand = new ModifyProfileCommand(this,authenticator,modifyProfileService);
        }


    }
}
