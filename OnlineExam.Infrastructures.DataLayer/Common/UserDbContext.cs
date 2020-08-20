using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Core.AppUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Common
{
    public class UserDbContext : IdentityDbContext<AppUser, MyIdentityRole, int>
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
