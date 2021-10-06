using Common.Abstractions;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAppEntityFramework.Services.Strategies
{
    public class GetByFirstNameJournalistStrategy : IGetByFirstNameStrategy<Journalist>
    {
        private readonly DataDbContextFactory contextFactory;

        public GetByFirstNameJournalistStrategy(DataDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        
        public async  Task<Journalist> ApplyGetByFirstName(string firstname)
        {
            using (DataDbContext context = contextFactory.CreateDbContext())
            {
                return await (context.Journalists
                    .FirstOrDefaultAsync(a => a.FirstName == firstname));
            }
        }
    }
}
