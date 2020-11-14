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
                    Code = "user",
                    Description = "نام کاربری باید بیشتر از 4 کاراکتر باشد  "
                });
            }
            if (user.UserName.Contains("0") ||
                user.UserName.Contains("1") ||
                user.UserName.Contains("2") ||
                user.UserName.Contains("3") ||
                user.UserName.Contains("4") ||
                user.UserName.Contains("5") ||
                user.UserName.Contains("6") ||
                user.UserName.Contains("7") ||
                user.UserName.Contains("8") ||
                user.UserName.Contains("9") ||
               user.UserName.Contains(" ")
                )
            {
                errors.Add(new IdentityError
                {
                    Code = "user",
                    Description = "نام کاربری نمیتواند شامل عدد و فاصله باشد   "
                });
            }
            if (user.UserName.Any(c=>c > 255))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "مجاز به استفاده از کاراکتر فارسی نیستید "
                });
            }
            if (password.Length < 6)
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "پسوورد باید حداقل 6 کاراکتر باشد  "
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
