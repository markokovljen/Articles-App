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
    public class ReviewDataService : IReviewService
    {
        private readonly DataDbContextFactory contextFactory;
        private readonly NonQueryDataService<Review> nonQueryDataService;

        public ReviewDataService(DataDbContextFactory contextFactory, NonQueryDataService<Review> nonQueryDataService)
        {
            this.contextFactory = contextFactory;
            this.nonQueryDataService = nonQueryDataService;
        }

        public async Task<Review> Create(Review entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        

        public async Task<Review> Get(int id)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                Review entity = await context.Reviews
                    .Include(a =>a.Article)
                     .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;

            }
        }

        public async Task<List<Review>> GetAll()
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                List<Review> entity = await context.Reviews
                    .Include(a => a.Article)
                     .ToListAsync();
                return entity;

            }
        }

        public async Task<Review> Update(int id, Review entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
