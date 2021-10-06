using Common.Abstractions;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services.Strategies
{
    public interface IGetByFirstNameStrategy<T> where T : Person
    {
        Task<T> ApplyGetByFirstName(string firstname);
    }
}
