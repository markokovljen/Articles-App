using KlijentskaAplikacija.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        private readonly IViewModelFactory<HomeViewModel> homeViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> loginViewModelFactory;
        private readonly IViewModelFactory<AddUserViewModel> addUserViewModelFactory;
        private readonly IViewModelFactory<ModifyProfileViewModel> modifyProfileViewModelFactory;

        public RootViewModelFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory, IViewModelFactory<LoginViewModel> loginViewModelFactory,
            IViewModelFactory<AddUserViewModel> addUserViewModelFactory, IViewModelFactory<ModifyProfileViewModel> modifyProfileViewModelFactory)
        {
            this.homeViewModelFactory = homeViewModelFactory;
            this.loginViewModelFactory = loginViewModelFactory;
            this.addUserViewModelFactory = addUserViewModelFactory;
            this.modifyProfileViewModelFactory = modifyProfileViewModelFactory;
            
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return loginViewModelFactory.CreateViewModel();       
                case ViewType.Home:
                    return homeViewModelFactory.CreateViewModel();
                case ViewType.AddUser:
                    return addUserViewModelFactory.CreateViewModel();
                case ViewType.ModifyProfile:
                    return modifyProfileViewModelFactory.CreateViewModel();
                
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel","viewType");
            }
        }
    }
}
