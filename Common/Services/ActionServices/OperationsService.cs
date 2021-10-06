using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ActionServices
{
    public enum UpdateResult
    {
        Success,
        Error,
        NotModified

    }

    public class OperationsService : IOperationsService
    {
        private readonly IArticleService articleService;
        public OperationsService(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<bool> AddArticle(string content, string title, string firstName, string lastName)
        {
            if (
                content==null || title == null || firstName == null || lastName == null ||
                content.Equals("") || title.Equals("") || firstName.Equals("") || lastName.Equals("") )
            {
                return false;
            }

            Journalist journalist = new Journalist { FirstName = firstName, LastName = lastName };
            Article article = new Article { Content = content, Title = title, Journalist = journalist };

            await articleService.Create(article);

            return true;
        }

        public async Task DeleteArticle(int id,string title)
        {
            bool success=await articleService.Delete(id);
            if (!success)
            {


                try
                {
                    Article temp = await articleService.GetByTitle(title);
                    if (temp == null)
                    {
                        throw new NullReferenceException();
                    }
                    await articleService.Delete(temp.Id);
                }
                catch (Exception)
                {

                    throw new Exception();
                }
                
            }
            
        }

        public async Task<List<Article>> DuplicateData()
        {
            List<Article> articles = await articleService.GetAll();
            await articleService.Duplicate(articles);

            return articles;
        }

        public async Task<List<Article>> RefreshArticles()
        {
            return await articleService.GetAll();
        }

        public async Task UnDuplicateData()
        {
            List<Article> articles = await articleService.GetAll();
            await articleService.UnDuplicate(articles);
        }

        public async Task<UpdateResult> UpdateArticle(int id, Article article)
        {
    
            Article temp = await articleService.Get(id);

            if (temp == null)
            {
                return UpdateResult.Error;
            }

            if (temp.Content.Equals(article.Content) && temp.Title.Equals(article.Title) && 
                temp.Journalist.FirstName.Equals(article.Journalist.FirstName) && 
                temp.Journalist.LastName.Equals(article.Journalist.LastName))
            {
                return UpdateResult.NotModified;
            }

            await articleService.Update(id, article);

             return UpdateResult.Success;
        }
    }
}
