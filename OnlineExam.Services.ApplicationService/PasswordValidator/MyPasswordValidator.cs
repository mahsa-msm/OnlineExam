using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Core.AppUsers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Services.ApplicationService.MyPasswordValidator
{
    public class MyPasswordValidator : PasswordValidator<AppUser>
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentResult = base.ValidateAsync(manager, user, password).Result;

            List<IdentityError> errors = new List<IdentityError>();
            if (password.Contains(" "))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "پسوورد نمیتواند شامل فاصله باشد "
                });
            }
            if (user.UserName.Length < 5)
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "نام کاربری باید بیشتر از 4 کاراکتر باشد  "
                });
            }
       
            if (!parentResult.Succeeded)
            {
                errors = parentResult.Errors.ToList();
            }

            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success
                );


        }
    }
}
