using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class ModifyProfileCommand : ICommand
    {
        private readonly ModifyProfileViewModel modifyProfileViewModel;
        private readonly IAuthenticator authenticator;
        private readonly IModifyProfileService modifyProfileService;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ModifyProfileCommand(ModifyProfileViewModel modifyProfileViewModel, IAuthenticator authenticator, IModifyProfileService modifyProfileService)
        {
            this.modifyProfileViewModel = modifyProfileViewModel;
            this.authenticator = authenticator;
            this.modifyProfileService = modifyProfileService;

            log4net.Config.XmlConfigurator.Configure();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool success = await modifyProfileService.ModifyProfile(modifyProfileViewModel.FirstName,
                modifyProfileViewModel.LastName, authenticator.UserState.CurrentUser.Id);
            if (!success)
            {
                modifyProfileViewModel.Warning = "You can not leave a field blank!";
                log.Warn("You can not leave a field blank!");
            }
            else
            {
                log.Info("Profile modifyed!");
                modifyProfileViewModel.Warning = string.Empty;
            }
        }

        
    }
}
