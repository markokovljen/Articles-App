using Common.HashText;
using Common.Models;
using Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.WPF.State.Authenticators.UserState
{
    public class LoggedInState : UserState
    {
        private readonly IUserJournalistService<User> userJournalistService;
        private readonly IHashText hashText;

        public LoggedInState(IUserJournalistService<User> userJournalistService, IHashText hashText, User currentUser)
        {
            this.userJournalistService = userJournalistService;
            this.hashText = hashText;
            this.CurrentUser = currentUser;
        }

        public override async Task Login(string username, string password, IAuthenticator authenticator)
        {

            return;
        }

        public override void Logout(IAuthenticator authenticator)
        {
            
            ChangeState(authenticator, new LoggedOutState(userJournalistService, hashText,null));
        }
    }
}
