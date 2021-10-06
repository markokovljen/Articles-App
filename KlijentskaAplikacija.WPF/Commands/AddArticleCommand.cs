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
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class AddArticleCommand : Command
    {
        private readonly IOperationsService operationsService;
        private readonly HomeViewModel homeViewModel;
        private List<Article> tempArticles;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AddArticleCommand(IOperationsService operationsService, HomeViewModel homeViewModel)
        {
            this.operationsService = operationsService;
            this.homeViewModel = homeViewModel;
            this.tempArticles = new List<Article>();

            log4net.Config.XmlConfigurator.Configure();

        }

       

        public override async void Execute(object parameter)
        {

            if (parameter == null)
            {

                bool succes = await operationsService.AddArticle(homeViewModel.ArticleContent, homeViewModel.ArticleTitle,
                    homeViewModel.FirstNameJournalist, homeViewModel.LastNameJournalist);
                if (!succes)
                {
                    homeViewModel.Warning2 = "You can not leave a field blank!";
                    log.Warn("You can not leave a field blank!");
                }
                else
                {
                    homeViewModel.Warning2 = string.Empty;
                    Journalist journalist = new Journalist { FirstName = homeViewModel.FirstNameJournalist, LastName = homeViewModel.LastNameJournalist };
                    Article newArticle = new Article
                    {
                        Content = homeViewModel.ArticleContent,
                        Title = homeViewModel.ArticleTitle,
                        Journalist = journalist
                    };
                    homeViewModel.Articles.Add(newArticle);
                    log.Info("New article added to UI and Database");

                    homeViewModel.SetCommand(this);

                }
            }
            else
            {
                Article tempArticle = tempArticles.LastOrDefault();
                homeViewModel.Articles.Add(tempArticle);
                await operationsService.AddArticle(tempArticle.Content, tempArticle.Title,
                    tempArticle.Journalist.FirstName, tempArticle.Journalist.LastName);
                tempArticles.Remove(tempArticle);
                log.Info("New article added to UI and Database");

            }
            
        }

       
        public override async void UnExecute()
        {
            Article tempArticle= homeViewModel.Articles.LastOrDefault();
            tempArticles.Add(tempArticle);
            await operationsService.DeleteArticle(tempArticle.Id,tempArticle.Title);
            homeViewModel.Warning = string.Empty;
            homeViewModel.Articles.Remove(tempArticle);
            log.Info("Article removed from UI and Database");

        }

        
    }
}
