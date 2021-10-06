using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAppEntityFramework
{
    public class DataDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>
    {
        public DataDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DataDbContext>();
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=RVAProjekatBaza;Trusted_Connection = True;");

            return new DataDbContext(options.Options);

        }

    }
}
