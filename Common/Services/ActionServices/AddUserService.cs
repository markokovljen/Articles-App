using Common.HashText;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ActionServices
{
    public class AddUserService : IAddUserService
    {
        private readonly IUserJournalistService<User> userJournalistService;
        private readonly IHashText hashText;

        public AddUserService(IUserJournalistService<User> userJournalistService, IHashText hashText)
        {
            this.userJournalistService = userJournalistService;
            this.hashText = hashText;
        }

        public async Task<RegistrationResult> AddUser(string username, string password, string confirmPassword, string firstName, string lastName, bool isAdministrator)
        {

            RegistrationResult result = RegistrationResult.Succes;

            if (username == null || password == null || confirmPassword == null || firstName == null || lastName == null ||
              username == "" || password == "" || confirmPassword == "" || firstName == "" || lastName == "")
            {
               return RegistrationResult.Blank;
            }


            if (!password.Equals(confirmPassword))
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            User userName = await userJournalistService.GetByUsername(username); 

            if (userName != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Succes)
            {
                string passwordHash = hashText.HashPassword(password);

                User user = new User()
                {
                    Username = username,
                    FirstName = firstName,
                    LastName = lastName,
                    PasswordHash = passwordHash,
                    IsAdministrator = isAdministrator
                };

                await userJournalistService.Create(user);
            }


            return result;

        }

        
    }
}
