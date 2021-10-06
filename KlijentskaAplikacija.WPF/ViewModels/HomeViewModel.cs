using Common.Models;
using Common.Services;
using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.Commands;
using KlijentskaAplikacija.WPF.Commands.Abstraction;
using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Navigators;
using KlijentskaAplikacija.WPF.ViewModels.Factories;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlijentskaAplikacija.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {


        private string articleTitle;
        public string ArticleTitle
        {
            get
            {
                return articleTitle;
            }
            set
            {
                articleTitle = value;
                OnPropertyChanged(nameof(ArticleTitle));

            }
        }



        private string articleContent;
        public string ArticleContent
        {
            get
            {
                return articleContent;
            }
            set
            {
                articleContent = value;
                OnPropertyChanged(nameof(ArticleContent));

            }
        }


        private string firstNameJournalist;
        public string FirstNameJournalist
        {
            get
            {
                return firstNameJournalist;
            }
            set
            {
                firstNameJournalist = value;
                OnPropertyChanged(nameof(FirstNameJournalist));

            }
        }

        private string lastNameJournalist;
        public string LastNameJournalist
        {
            get
            {
                return lastNameJournalist;
            }
            set
            {
                lastNameJournalist = value;
                OnPropertyChanged(nameof(LastNameJournalist));

            }
        }

        private string warning2;
        public string Warning2
        {
            get
            {
                return warning2;
            }
            set
            {
                warning2 = value;
                OnPropertyChanged(nameof(Warning2));
            }
        }



        private Article selectedArticle;
        public Article SelectedArticle
        {
            get
            {
                return selectedArticle;
            }
            set
            {
                selectedArticle = value;
                OnPropertyChanged(nameof(SelectedArticle));
            }
        }

        private string warning;
        public string Warning
        {
            get
            {
                return warning;
            }
            set
            {
                warning = value;
                OnPropertyChanged(nameof(Warning));
            }
        }

        private string searchResult;
        public string SearchResult
        {
            get
            {
                return searchResult;
            }
            set
            {
                searchResult = value;
                OnPropertyChanged(nameof(SearchResult));
            }
        }

        private ObservableCollection<Article> articles;
        public ObservableCollection<Article> Articles
        {
            get
            {
                return articles;
            }
            set
            {
                articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }

        public ObservableCollection<Review> Reviews { get; set; }

        public List<Command> History { get; set; }


        public void SetCommand(Command command)
        {
            if (History.LastOrDefault()!=command)
            {
                
                for(int i = Index+1; i < History.Count;)
                {
                    History.RemoveAt(i);
                }                     
            }

            History.Add(command);
            Index = History.Count - 1;

        }

        public int Index { get; set; }


        public async Task LoadArticles(IArticleService articleService )
        {
            List<Article> articles= await articleService.GetAll();
            Articles = new ObservableCollection<Article>(articles);
            

        }
        public async Task LoadReviews(IReviewService reviewService)
        {
            List<Review> reviews = await reviewService.GetAll();
            Reviews = new ObservableCollection<Review>(reviews);
        }

        public ICommand AddArticleCommand { get; set; }
        public ICommand UpdateArticleCommand { get; set; }

        public ICommand DeleteArticleCommand { get; set; }
        public ICommand DuplicateDataCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand UndoCommand { get; set; }

        public ICommand RedoCommand { get; set; }

        public ICommand RefreshDisplayCommand { get; set; }

        

        public HomeViewModel(IArticleService articleService, IReviewService reviewService, IOperationsService operationsService)
        {
            History = new List<Command>();   
            Index = -1;
            Task.Run(() => this.LoadArticles(articleService)).Wait(); // -> blokira thread(i sam UI) i ceka da ucita sve artikle pa tek onda nastvalja sa radom
            Task.Run(() => this.LoadReviews(reviewService)).Wait();
            //new Action(async () => await LoadArticles(articleService))(); -> ne blokira thread , tacnije nece sacekati da ucita artikle

            AddArticleCommand = new AddArticleCommand(operationsService, this);
            UpdateArticleCommand = new UpdateArticleCommand(operationsService, this,articleService,new RefreshDisplayCommand(operationsService, this));
            DeleteArticleCommand = new DeleteArticleCommand(operationsService, this);
            DuplicateDataCommand = new DuplicateDataCommand(operationsService,this);
            SearchCommand = new SearchCommand(this, articleService);
            UndoCommand = new UndoCommand(this);
            RedoCommand = new RedoCommand(this);
            RefreshDisplayCommand = new RefreshDisplayCommand(operationsService,this);

            

        }
    }
}
