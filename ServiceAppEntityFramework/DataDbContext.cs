using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAppEntityFramework
{
    public class DataDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Journalist> Journalists { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DataDbContext(DbContextOptions options) : base(options) { }

        

    }
}
