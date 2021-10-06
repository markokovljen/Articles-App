using Common.Models;
using Common.Services;
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
    public class UpdateArticleCommand : Command
    {
        private readonly IOperationsService operationsService;        
        private readonly HomeViewModel homeViewModel;
        private readonly IArticleService articleService;
        private Article tempArticleOldValue;
        private Article tempArticleNewValue;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UpdateArticleCommand(IOperationsService operationsService, HomeViewModel homeViewModel, IArticleService articleService)
        {
            this.operationsService = operationsService;
            this.homeViewModel = homeViewModel;
            this.articleService = articleService;

            log4net.Config.XmlConfigurator.Configure();

        }

        

        public override async void Execute(object parameter)
        {
            if (parameter == null)
            {

                if (homeViewModel.SelectedArticle == null)
                {
                    homeViewModel.Warning = "You need to select item first!";
                    log.Warn("You need to select item first!");
                    return;
                }

                tempArticleOldValue=await articleService.Get(homeViewModel.SelectedArticle.Id);
                tempArticleNewValue = homeViewModel.SelectedArticle;

                bool success = await operationsService.UpdateArticle(homeViewModel.SelectedArticle.Id, homeViewModel.SelectedArticle);
                if (!success)
                {
                    homeViewModel.Warning = "You need to make some changes to update!";
                    log.Warn("You need to make some changes to update!");
                }
                else
                {

                    //if(homeViewModel.Articles.Count!=0 && homeViewModel.History[homeViewModel.History.Count-1] is UpdateArticleCommand)
                    //{
                    //    homeViewModel.History.RemoveAt(homeViewModel.History.Count - 1);
                    //}

                    log.Info("Article updated!");
                    homeViewModel.Warning = string.Empty;

                    homeViewModel.SetCommand(this);
                    
                }
            }
            else
            {
                await operationsService.UpdateArticle(tempArticleNewValue.Id, tempArticleNewValue);
                int index = homeViewModel.Articles.IndexOf(tempArticleOldValue);
                homeViewModel.Articles.Insert(index, tempArticleNewValue);
                homeViewModel.Articles.RemoveAt(index + 1);
                log.Info("Article updated!");
            }
        }

        public async override void UnExecute()
        {
            await operationsService.UpdateArticle(tempArticleOldValue.Id, tempArticleOldValue);
            int index = homeViewModel.Articles.IndexOf(tempArticleNewValue);
            homeViewModel.Articles.Insert(index, tempArticleOldValue);
            homeViewModel.Articles.RemoveAt(index+1);
            log.Info("Article updated to first state!");


        }
    }
}
