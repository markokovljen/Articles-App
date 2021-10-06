using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ActionServices
{
    public interface IModifyProfileService 
    {
        Task<bool> ModifyProfile(string firstName, string lastName,int id);
    }
}
