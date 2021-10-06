using Common.Services.ActionServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.ViewModels.Factories
{
    public class AddUserViewModelFactory : IViewModelFactory<AddUserViewModel>
    {
        private readonly IAddUserService addUserService;

        public AddUserViewModelFactory(IAddUserService addUserService)
        {
            this.addUserService = addUserService;
        }

        public AddUserViewModel CreateViewModel()
        {
            return new AddUserViewModel(addUserService);
        }
    }
}
