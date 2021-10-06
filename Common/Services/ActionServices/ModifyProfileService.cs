using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ActionServices
{
    public class ModifyProfileService : IModifyProfileService
    {
        private readonly IUserJournalistService<User> userJournalistService;

        public ModifyProfileService(IUserJournalistService<User> userJournalistService)
        {
            this.userJournalistService = userJournalistService;
        }

        public async Task<bool> ModifyProfile(string firstName, string lastName, int id)
        {
           
            if (firstName.Equals("")|| lastName.Equals(""))
            {
                return false;
            }

            User user = await userJournalistService.Get(id);
            user.FirstName = firstName;
            user.LastName = lastName;
            await userJournalistService.Update(id, user);

            return true;

        }
    }
}
