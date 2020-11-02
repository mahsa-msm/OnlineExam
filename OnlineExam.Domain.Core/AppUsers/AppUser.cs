using Microsoft.AspNetCore.Identity;

namespace OnlineExam.Domain.Core.AppUsers
{
    public class AppUser : IdentityUser<int>
    {
    }
    public class MyIdentityRole : IdentityRole<int>
    {

    }
}
