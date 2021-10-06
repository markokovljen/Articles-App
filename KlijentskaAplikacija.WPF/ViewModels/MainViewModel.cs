using Common.Models;
using Common.Services;
using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.Commands;
using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using KlijentskaAplikacija.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        
        public IAuthenticator Authenticator { get; }

        public ICommand UpdateCurrentViewModelCommand { get; }

        public ICommand LogOutCommand { get; }

              
        public MainViewModel(INavigator navigator,IRootViewModelFactory viewModelFactory, IAuthenticator authenticator,
            IReviewService reviewsService,IArticleService articleService, IOperationsService operationsService)
        {
            new Action(async () => await InitializingData(articleService, reviewsService, operationsService))();
            //Task.Run(() => this.InitializingData(service)).Wait();
            Navigator = navigator;
            Authenticator = authenticator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
            LogOutCommand = new LogOutCommand(authenticator, new UpdateCurrentViewModelCommand(navigator, viewModelFactory));
        }   

        public async Task<bool> InitializingData(IArticleService articleService, IReviewService reviewsService,
            IOperationsService operationsService)
        {
            bool success = true;

            List<Article> articles = await articleService.GetAll();
            if (articles.Count == 0)
            {
                await operationsService.AddArticle("Blank content", "Title1", "Vladan", "Tegeltija");
                
            }
            else
            {
                success = false;

            }
            return success;
        }

        
    }
}
