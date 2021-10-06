using Common.HashText;
using Common.Models;
using Common.Services;
using KlijentskaAplikacija.WPF.State.Authenticators.UserState;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.WPF.State.Authenticators
{
    public class Authenticator :ObservableObject, IAuthenticator
    {
       
        private readonly IUserJournalistService<User> userJournalistService;
        private readonly IHashText hashText;
        

        public Authenticator(IUserJournalistService<User> userJournalistService, IHashText hashText)
        {

            this.userJournalistService = userJournalistService;
            this.hashText = hashText;
            this.UserState = new LoggedOutState(userJournalistService,hashText,null);
            this.UserState.CurrentUser = new User();
        }


        public UserState.UserState UserState { get; set; }
        public bool IsLoggedIn => this.UserState is LoggedInState;

       

        public void ChangeState(UserState.UserState state)
        {
            this.UserState = state;
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(UserState));
        }

        public async Task<bool> Login(string username, string password)
        {
            bool succes = true;

            try
            {
                
                await this.UserState.Login(username, password, this);
            }
            catch (Exception)
            {

                succes = false;
            }


            return succes;
        }

        public void Logout()
        {
            this.UserState.Logout(this);
        }

        
    }
}
