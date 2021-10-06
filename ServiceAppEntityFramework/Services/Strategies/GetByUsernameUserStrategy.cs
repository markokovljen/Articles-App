using Common.Abstractions;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services.Strategies
{
    public class GetByUsernameUserStrategy : IGetByUsernameStrategy<User>
    {
        private readonly DataDbContextFactory contextFactory;

        public GetByUsernameUserStrategy(DataDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        
        public async Task<User> ApplyGetByUsername(string username)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                return await(context.Users
                    .FirstOrDefaultAsync(a => a.Username == username));
            }
        }
    }
}
