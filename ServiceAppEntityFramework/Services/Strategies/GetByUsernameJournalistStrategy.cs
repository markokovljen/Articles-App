using Common.Abstractions;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services.Strategies
{
    public class GetByUsernameJournalistStrategy : IGetByUsernameStrategy<Journalist>
    {
        public Task<Journalist> ApplyGetByUsername(string username)
        {
            return null;
        }
    }
}
