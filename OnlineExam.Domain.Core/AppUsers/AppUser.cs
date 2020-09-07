using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Core.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Core.AppUsers
{
    public class AppUser : IdentityUser<int>
    {
        public virtual ICollection<Answer> Answers { get; set; }
    }
    public class MyIdentityRole : IdentityRole<int>
    {

    }
}
