using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ActionServices
{
    public interface IOperationsService
    {
        Task<bool> AddArticle(string content,string title,string firstName,string lastName);
        Task<UpdateResult> UpdateArticle(int id, Article article);
        Task DeleteArticle(int id,string title);
        Task<List<Article>> RefreshArticles();
        Task<List<Article>> DuplicateData();
        Task UnDuplicateData();
    }
}
