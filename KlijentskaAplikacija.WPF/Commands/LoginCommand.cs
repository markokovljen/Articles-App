using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using KlijentskaAplikacija.WPF.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticator authenticator;
        private readonly LoginViewModel loginViewModel;
        private readonly IRenavigator renavigator;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel,IRenavigator renavigator)
        {
            this.authenticator = authenticator;
            this.loginViewModel = loginViewModel;
            this.renavigator = renavigator;

            log4net.Config.XmlConfigurator.Configure();

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)//async void je okej ovde zato sto nasa login metoda nece bacati exceptione
        {
            bool success = await authenticator.Login(loginViewModel.Username,parameter.ToString());

            if (success)
            {
                log.Info("User has logged in!");
                
                renavigator.Renavigate();
            }
        }
    }
}
