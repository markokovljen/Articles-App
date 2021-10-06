using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface IArticleService : IDataService<Article>
    {
        Task<Article> GetByTitle(string title);
        Task Duplicate(List<Article> articles);

        Task UnDuplicate(List<Article> articles);
    }
}
