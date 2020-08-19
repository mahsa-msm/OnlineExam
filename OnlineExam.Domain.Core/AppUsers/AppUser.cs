using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
