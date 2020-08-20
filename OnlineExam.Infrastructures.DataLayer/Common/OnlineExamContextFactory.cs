using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Common
{
    public class OnlineExamContextFactory : IDesignTimeDbContextFactory<OnlineExamDbContext>
    {
        public OnlineExamDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OnlineExamDbContext>();
            builder.UseSqlServer("Server = hqit-user7\\morsamsqlserver; Database = OnlineExam; Trusted_Connection = True; MultipleActiveResultSets = true");
            return new OnlineExamDbContext(builder.Options);
        }
    }
}
