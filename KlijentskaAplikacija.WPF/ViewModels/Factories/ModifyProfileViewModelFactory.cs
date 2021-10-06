using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.ViewModels.Factories
{
    public class ModifyProfileViewModelFactory : IViewModelFactory<ModifyProfileViewModel>
    {
        private readonly IAuthenticator authenticator;
        private readonly IModifyProfileService modifyProfileService;

        public ModifyProfileViewModelFactory(IAuthenticator authenticator, IModifyProfileService modifyProfileService)
        {
            this.authenticator = authenticator;
            this.modifyProfileService = modifyProfileService;
        }

        public ModifyProfileViewModel CreateViewModel()
        {
            return new ModifyProfileViewModel(authenticator, modifyProfileService);
        }
    }
}
