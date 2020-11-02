//using Microsoft.AspNetCore.Identity;
//using OnlineExam.Domain.Core.AppUsers;
//using OnlineExam.Services.ApplicationService.UserAccount.Interface;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace OnlineExam.Services.ApplicationService.UserAccount
//{

//    public class UserService : IUserService
//    {
//        //private UserManager<AppUser> userManager;
//        //private SignInManager<AppUser> signInManager;


//        public async void Login(MyLoginModel loginModel)
//        {
//            AppUser user = await userManager.FindByNameAsync(loginModel.Name);


//            if (user != null)
//            {
//                await signInManager.SignOutAsync();
//                if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
//                {
//                   //return Redirect(loginModel?.ReturnUrl ?? "/");
//                }
//            }
//        }



//        public void SingUp(MyCreeateAppUser creeateAppUser)
//        {

//            AppUser user = new AppUser
//            {
//                Email = creeateAppUser.Email,
//                UserName = creeateAppUser.Name

//            };

//            var result = userManager.CreateAsync(user, creeateAppUser.Password).Result;

//            if (result.Succeeded)
//            {
//                var result2 = userManager.AddToRoleAsync(user, "user").Result;
//                if (result2.Succeeded)
//                {

//                    //return RedirectToAction("Index");
//                }
//                else
//                {
//                    foreach (var item in result2.Errors)
//                    {
//                        //ModelState.AddModelError(item.Code, item.Description);
//                    }
//                }

//            }
//            else
//            {
//                foreach (var item in result.Errors)
//                {
//                    //ModelState.AddModelError(item.Code, item.Description);
//                }


//            }

//        }

//    }
//}



