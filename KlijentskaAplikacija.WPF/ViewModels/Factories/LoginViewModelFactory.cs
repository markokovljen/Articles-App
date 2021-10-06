using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator authenticator;
        private readonly IRenavigator renavigator;

        public LoginViewModelFactory(IAuthenticator authenticator,IRenavigator renavigator)
        {
            this.authenticator = authenticator;
            this.renavigator = renavigator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(authenticator,renavigator);
        }
    }
}
