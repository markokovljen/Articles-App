using Common.Models;
using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class RefreshDisplayCommand : ICommand
    {
        private readonly IOperationsService operationsService;
        private readonly HomeViewModel homeViewModel;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RefreshDisplayCommand(IOperationsService operationsService, HomeViewModel homeViewModel)
        {
            this.operationsService = operationsService;
            this.homeViewModel = homeViewModel;

            log4net.Config.XmlConfigurator.Configure();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async  void Execute(object parameter)
        {
            homeViewModel.Articles=new ObservableCollection<Article>(await operationsService.RefreshArticles());
            log.Info("UI refresed");

        }
    }
}
