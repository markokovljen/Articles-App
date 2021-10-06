using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.WPF.State.Authenticators.UserState
{
    public abstract class UserState
    {
        public User CurrentUser { get; set; }
        public abstract Task Login(string username,string password,IAuthenticator authenticator);
        public abstract void Logout(IAuthenticator authenticator);

        public void ChangeState(IAuthenticator authenticator, UserState state)
        {
            authenticator.ChangeState(state);
        }
    }
}
