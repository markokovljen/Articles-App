using Common.Models;
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
    public class DuplicateDataCommand : Command
    {
        private readonly IOperationsService operationsService;
        private readonly HomeViewModel homeViewModel;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DuplicateDataCommand(IOperationsService operationsService,HomeViewModel homeViewModel)
        {
            this.operationsService = operationsService;
            this.homeViewModel = homeViewModel;

            log4net.Config.XmlConfigurator.Configure();
        }

       
        public override async void Execute(object parameter)
        {
           List<Article> articles = await operationsService.DuplicateData();
            
            foreach(var item in articles)
            {
                homeViewModel.Articles.Add(item);
            }
            if(parameter==null)
            homeViewModel.SetCommand(this);

            log.Info("Database duplicated!");

        }

        public async override void UnExecute()
        {
            await operationsService.UnDuplicateData();

            int length = homeViewModel.Articles.Count;
            for (int i = (homeViewModel.Articles.Count/2); i < length; i++)
            {
                homeViewModel.Articles.RemoveAt(homeViewModel.Articles.Count-1);
            }

            log.Info("Database Unduplicated!");
        }
    }
}
