using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaAplikacija.WPF.State.Authenticators
{
    public interface IAuthenticator 
    {
        bool IsLoggedIn { get; }
        public UserState.UserState UserState { get; }

        Task<bool> Login(string username, string password);
        void Logout();

        void ChangeState(UserState.UserState state);
        

    }
}
