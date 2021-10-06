using Common.Models;
using Common.Services;
using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlijentskaAplikacija.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        private readonly IArticleService articleService;
        private readonly IReviewService reviewService;
        private readonly IOperationsService operationsService;
        

        public HomeViewModelFactory(IArticleService articleService, IReviewService reviewService, 
            IOperationsService operationsService)
        {
            this.articleService = articleService;
            this.reviewService = reviewService;
            this.operationsService = operationsService;
            
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(articleService, reviewService, operationsService);
        }
    }
}
