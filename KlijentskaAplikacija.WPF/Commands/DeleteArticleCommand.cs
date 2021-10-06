using Common.Models;
using Common.Services;
using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.Commands.Abstraction;
using KlijentskaAplikacija.WPF.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class DeleteArticleCommand : Command
    {
        private readonly IOperationsService operationsService;
        private readonly HomeViewModel homeViewModel;
        private List<Article> tempArticlesUndo;
        private List<Article> tempArticlesRedo;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DeleteArticleCommand(IOperationsService operationsService, HomeViewModel homeViewModel)
        {
            this.operationsService = operationsService;
            this.homeViewModel = homeViewModel;
            tempArticlesUndo = new List<Article>();
            tempArticlesRedo = new List<Article>();

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

                await operationsService.DeleteArticle(homeViewModel.SelectedArticle.Id, homeViewModel.SelectedArticle.Title);
                homeViewModel.Warning = string.Empty;
                tempArticlesUndo.Add(homeViewModel.SelectedArticle);
                homeViewModel.Articles.Remove(homeViewModel.SelectedArticle);
                log.Info("Article removed from UI and Database!");

                homeViewModel.SetCommand(this);

            }
            else
            {
                Article tempArticle= tempArticlesRedo.LastOrDefault();
                await operationsService.DeleteArticle(tempArticle.Id, tempArticle.Title);
                tempArticlesUndo.Add(tempArticle);
                tempArticlesRedo.Remove(tempArticle);
                homeViewModel.Articles.Remove(tempArticle);
                log.Info("Article removed from UI and Database!");


            }

        }

        public override async void UnExecute()
        {
            Article tempArticle = tempArticlesUndo.LastOrDefault();
            if (tempArticle == null)
                return;
            await operationsService.AddArticle(tempArticle.Content, tempArticle.Title,
                    tempArticle.Journalist.FirstName, tempArticle.Journalist.LastName);
            homeViewModel.Articles.Add(tempArticle);
            tempArticlesRedo.Add(tempArticle);
            tempArticlesUndo.Remove(tempArticle);
            log.Info("New article added to UI and Database");

        }
    }
}
