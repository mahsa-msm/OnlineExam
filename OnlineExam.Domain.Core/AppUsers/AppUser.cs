using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Core.Answers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineExam.Domain.Core.AppUsers
{
    public class AppUser : IdentityUser<int>
    {
    }
    public class MyIdentityRole : IdentityRole<int>
    {

    }
}
