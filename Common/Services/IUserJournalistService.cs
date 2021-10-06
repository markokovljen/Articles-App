using Common.Abstractions;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface IUserJournalistService<T> : IDataService<T> 
    {
        public Task<T> GetByFirstName(string firstname);
        public Task<T> GetByUsername(string username);
    }
}
