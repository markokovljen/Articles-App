using Common.HashText;
using Common.Models;
using Common.Services;
using Common.Services.ActionServices;
using KlijentskaAplikacija.WPF.State.Authenticators;
using KlijentskaAplikacija.WPF.State.Authenticators.UserState;
using KlijentskaAplikacija.WPF.State.Navigators;
using KlijentskaAplikacija.WPF.ViewModels;
using KlijentskaAplikacija.WPF.ViewModels.Factories;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using ServiceAppEntityFramework;
using ServiceAppEntityFramework.Services;
using ServiceAppEntityFramework.Services.Common;
using ServiceAppEntityFramework.Services.Strategies;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace KlijentskaAplikacija.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        protected override void OnStartup(StartupEventArgs e)
        {


            log4net.Config.XmlConfigurator.Configure();
            log.Info("        =============  Started Logging  =============        ");

            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

           

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<DataDbContextFactory>();
            services.AddSingleton<IUserJournalistService<User>, UserJournalistDataService<User>>();
            services.AddSingleton<IUserJournalistService<Journalist>, UserJournalistDataService<Journalist>>();
            services.AddSingleton<IArticleService, ArticleDataService>();
            services.AddSingleton<IReviewService, ReviewDataService>();

            services.AddSingleton<NonQueryDataService<User>>();
            services.AddSingleton<NonQueryDataService<Article>>();
            services.AddSingleton<NonQueryDataService<Review>>();
            services.AddSingleton<NonQueryDataService<Journalist>>();
            services.AddSingleton<IGetByFirstNameStrategy<User>, GetByFirstNameUserStrategy>();
            services.AddSingleton<IGetByFirstNameStrategy<Journalist>, GetByFirstNameJournalistStrategy>();
            services.AddSingleton<IGetByUsernameStrategy<Journalist>, GetByUsernameJournalistStrategy>();
            services.AddSingleton<IGetByUsernameStrategy<User>, GetByUsernameUserStrategy>();
            services.AddSingleton<IHashText, HashText>();
            services.AddSingleton<IAddUserService, AddUserService>();
            services.AddSingleton<IModifyProfileService, ModifyProfileService>();
            services.AddSingleton<IOperationsService, OperationsService>();

            services.AddSingleton<IRootViewModelFactory, RootViewModelFactory>();
            services.AddSingleton <IViewModelFactory<HomeViewModel>,HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<AddUserViewModel>, AddUserViewModelFactory>();
            services.AddSingleton<IViewModelFactory<ModifyProfileViewModel>, ModifyProfileViewModelFactory>();
            

            services.AddSingleton<IViewModelFactory<LoginViewModel>>((services) =>
            new LoginViewModelFactory(services.GetRequiredService<IAuthenticator>(),
            new ViewModelFactoryRenavigator<HomeViewModel>(services.GetRequiredService<INavigator>(),
            services.GetRequiredService<IViewModelFactory<HomeViewModel>>())));
            
            

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddScoped <MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
             
            return services.BuildServiceProvider();

        }

        
    }
}
