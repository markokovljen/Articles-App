using KlijentskaAplikacija.WPF.Commands;
using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
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

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IAuthenticator authenticator,IRenavigator renavigator)
        {
            LoginCommand = new LoginCommand(authenticator,this, renavigator);
        }




    }
}
