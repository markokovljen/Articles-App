using Common.Abstractions;
using Common.Models;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using ServiceAppEntityFramework.Services.Common;
using ServiceAppEntityFramework.Services.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services
{
    public class UserJournalistDataService<T> : IUserJournalistService<T> where T : Person
    {
        private readonly DataDbContextFactory contextFactory;
        private readonly NonQueryDataService<T> nonQueryDataService;
        private readonly IGetByFirstNameStrategy<T> firstnameStrategy;
        private readonly IGetByUsernameStrategy<T> usernameStrategy;

        public UserJournalistDataService(DataDbContextFactory contextFactory, NonQueryDataService<T> nonQueryDataService, 
            IGetByFirstNameStrategy<T> firstnameStrategy,IGetByUsernameStrategy<T> usernameStrategy)
        {
            this.contextFactory = contextFactory;
            this.nonQueryDataService = nonQueryDataService;
            this.firstnameStrategy = firstnameStrategy;
            this.usernameStrategy = usernameStrategy;
        }

        public async Task<T> Create(T entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }


        public async Task<T> Get(int id)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

 
        public async Task<List<T>> GetAll()
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                List<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> GetByFirstName(string firstname)
        {
            return await firstnameStrategy.ApplyGetByFirstName(firstname);
        }

        public async Task<T> GetByUsername(string username)
        {
            return await usernameStrategy.ApplyGetByUsername(username);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
