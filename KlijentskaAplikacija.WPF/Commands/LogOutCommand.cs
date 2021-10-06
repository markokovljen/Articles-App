using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class LogOutCommand : ICommand
    {
        private readonly IAuthenticator authenticator;
        private readonly ICommand updateCurrentViewModelCommand;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LogOutCommand(IAuthenticator authenticator, ICommand updateCurrentViewModelCommand)
        {
            this.authenticator = authenticator;
            this.updateCurrentViewModelCommand = updateCurrentViewModelCommand;

            log4net.Config.XmlConfigurator.Configure();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            authenticator.Logout();
            log.Info("User has logged out!");
            updateCurrentViewModelCommand.Execute(ViewType.Login);

        }
    }
}
