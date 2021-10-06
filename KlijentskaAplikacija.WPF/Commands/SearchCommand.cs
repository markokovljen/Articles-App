using Common.Models;
using Common.Services;
using KlijentskaAplikacija.WPF.Commands.Abstraction;
using KlijentskaAplikacija.WPF.ViewModels;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.Commands
{
    public class SearchCommand : Command
    {
        private readonly HomeViewModel homeViewModel;
        private readonly IArticleService articleService;
        private string tempTitle;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public SearchCommand(HomeViewModel homeViewModel,IArticleService articleService)
        {
            this.homeViewModel = homeViewModel;
            this.articleService = articleService;

            log4net.Config.XmlConfigurator.Configure();
        }

        

        public override void Execute(object parameter)
        {
            if (parameter == null)
            {
                tempTitle = homeViewModel.SearchResult;
                homeViewModel.SetCommand(this);
            }
            else
            {
                homeViewModel.SearchResult = tempTitle;
            }
                
                Article searchedArticle = null;
                foreach (var item in homeViewModel.Articles)
                {
                    if (item.Title.Equals(homeViewModel.SearchResult))
                    {
                        searchedArticle = item;
                        break;

                    }
                }

                homeViewModel.Articles.Clear();

                if (searchedArticle != null)
                {
                    homeViewModel.Articles.Add(searchedArticle);
                }

            log.Info("Executed search by title");


        }
            
        public async override void UnExecute()
        {
            List<Article> tempArticles = await articleService.GetAll();
            foreach(var item in tempArticles)
            {
                homeViewModel.Articles.Add(item);
            }

            log.Info("Unexecuted search by title");
        }
    }
}
