using Common.Abstractions;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services.Strategies
{
    public class GetByFirstNameUserStrategy : IGetByFirstNameStrategy<User>
    {
        private readonly DataDbContextFactory contextFactory;

        public GetByFirstNameUserStrategy(DataDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        
        public async Task<User> ApplyGetByFirstName(string firstname)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                return await (context.Users
                    .FirstOrDefaultAsync(a => a.FirstName == firstname));
            }
        }
    }
}
