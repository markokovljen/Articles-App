using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ActionServices
{
    public enum RegistrationResult
    {
        Succes,
        PasswordDoNotMatch,
        UsernameAlreadyExists,
        Blank
    }
    public interface IAddUserService 
    {
        Task<RegistrationResult> AddUser(string username, string password, string confirmPassword, string firstName, string lastName, bool isAdministrator);
    }
}
