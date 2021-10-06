using KlijentskaAplikacija.WPF.State.Navigators;
using KlijentskaAplikacija.WPF.ViewModels;
using KlijentskaAplikacija.WPF.ViewModels.Factories;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator navigator;
        private readonly IRootViewModelFactory viewModelRootFactory;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UpdateCurrentViewModelCommand(INavigator navigator, IRootViewModelFactory viewModelRootFactory)
        {
            this.navigator = navigator;
            this.viewModelRootFactory = viewModelRootFactory;

            log4net.Config.XmlConfigurator.Configure();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                log.Info("Updated current view model");
                navigator.CurrentViewModel = viewModelRootFactory.CreateViewModel(viewType);
            }
        }
    }
}
