using KlijentskaAplikacija.WPF.ViewModels;
using KlijentskaAplikacija.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.State.Navigators
{
    public class ViewModelFactoryRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator navigator;
        private readonly IViewModelFactory<TViewModel> viewModelFactory;

        public ViewModelFactoryRenavigator(INavigator navigator, IViewModelFactory<TViewModel> viewModelFactory)
        {
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public void Renavigate()
        {
            navigator.CurrentViewModel = viewModelFactory.CreateViewModel();
        }
    }
}
