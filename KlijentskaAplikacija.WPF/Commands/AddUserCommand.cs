using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.Commands.Abstraction;
using KlijentskaAplikacija.WPF.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class AddUserCommand : Command
    {
        private readonly IAddUserService addUserService;
        private readonly AddUserViewModel addUserViewModel;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AddUserCommand(IAddUserService addUserService, AddUserViewModel addUserViewModel)
        {
            this.addUserService = addUserService;
            this.addUserViewModel = addUserViewModel;

            log4net.Config.XmlConfigurator.Configure();
        }

        

        public override async void Execute(object parameter)
        {
            

            RegistrationResult result= await addUserService.AddUser(addUserViewModel.Username, addUserViewModel.Password,
                addUserViewModel.ConfirmPassword, addUserViewModel.FirstName, addUserViewModel.LastName, addUserViewModel.IsAdministrator);
            if (result == RegistrationResult.Blank)
            {
                addUserViewModel.Warning = "You can not leave a field blank!";
                log.Warn("You can not leave a field blank!");
            }
            else if (result == RegistrationResult.Succes)
            {
                addUserViewModel.Warning = string.Empty;
                log.Warn("User added to Database!");
            }
            else if (result == RegistrationResult.UsernameAlreadyExists)
            {
                addUserViewModel.Warning = "Username already exists!";
                log.Error("Username already exists!");
            }
            else
            {
                addUserViewModel.Warning = "Password do not match!";
                log.Error("Password do not match!");
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
