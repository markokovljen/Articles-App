using Common.HashText;
using Common.Models;
using Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.WPF.State.Authenticators.UserState
{
    public class LoggedOutState : UserState
    {
        private readonly IUserJournalistService<User> userJournalistService;
        private readonly IHashText hashText;

        public LoggedOutState(IUserJournalistService<User> userJournalistService, IHashText hashText,User currentUser)
        {
            this.userJournalistService = userJournalistService;
            this.hashText = hashText;
            this.CurrentUser = currentUser;
        }

        public override async Task Login(string username, string password, IAuthenticator authenticator)
        {
            User currentUser= await userJournalistService.GetByUsername(username);

            if (currentUser == null)
            {
                throw new Exception();
            }

            bool passwordsMatch = hashText.HashPassword(password).Equals(currentUser.PasswordHash);

            if (!passwordsMatch)
            {
                throw new Exception();
            }

            ChangeState(authenticator, new LoggedInState(userJournalistService,hashText, currentUser));

         
        }

        public override void Logout(IAuthenticator authenticator)
        {
            return;
        }
    }
}
