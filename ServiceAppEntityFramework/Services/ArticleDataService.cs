using Common.Models;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using ServiceAppEntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services
{
    public class ArticleDataService : IArticleService
    {
        private readonly DataDbContextFactory contextFactory;
        private readonly NonQueryDataService<Article> nonQueryDataService;

        public ArticleDataService(DataDbContextFactory contextFactory, NonQueryDataService<Article> nonQueryDataService)
        {
            this.contextFactory = contextFactory;
            this.nonQueryDataService = nonQueryDataService;
        }

        public async  Task<Article> Create(Article entity)
        {
              return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task Duplicate(List<Article> articles)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {

                for(int i = 0; i < articles.Count; i++)
                {
                    articles[i].Id = 0;
                    articles[i].Journalist.Id = 0;

                    await context.Set<Article>().AddAsync(articles[i]);
                    await context.SaveChangesAsync();
                }

                
            }
        }

        public async Task UnDuplicate(List<Article> articles)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {

                for (int i = (articles.Count/2); i < articles.Count; i++)
                {

                    context.Set<Article>().Remove(articles[i]);
                    await context.SaveChangesAsync();
                }


            }
        }

        public async Task<Article> Get(int id)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                Article entity = await context.Articles
                    .Include(a=>a.Journalist)
                     .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;

            }
        }

        public async Task<List<Article>> GetAll()
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                List<Article> entities = await context.Articles
                    .Include(a => a.Journalist)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Article> GetByTitle( string title)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                return await context.Articles
                    .Include(a => a.Journalist)
                    .FirstOrDefaultAsync(a => a.Title==title);
            }
        }

        public async Task<Article> Update(int id, Article entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
