using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services.Strategies
{
    public interface IGetByUsernameStrategy<T> where T : Person
    {
        Task<T> ApplyGetByUsername(string username);
    }
}
