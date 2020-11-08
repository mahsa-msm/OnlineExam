using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Endpoint.WebUI.Models.UserApp;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.MVC.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<MyIdentityRole> roleManager;

        public UserAccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signInMgr, RoleManager<MyIdentityRole> roleManager
  )
        {
            userManager = userMgr;
            signInManager = signInMgr;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new MyLoginModel
            {

                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MyLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginModel.Name);


                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.Name

                };

                var result = userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    var result2 = userManager.AddToRoleAsync(user, "user").Result;
                    if (result2.Succeeded)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result2.Errors)
                        {
                            ModelState.AddModelError(item.Code, item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View(model);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }


        public IActionResult Role()
        {
            MyIdentityRole role = new MyIdentityRole
            {
                Name = "user"
            };
            roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmin(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.Name
                };
                var userExists = userManager.FindByNameAsync(user.UserName).Result;
                if (userExists == null || userExists.Id == 0)
                {
                    var result = userManager.CreateAsync(user, model.Password).Result;
                    if (result.Succeeded)
                    {
                        var result2 = userManager.AddToRoleAsync(user, "admin").Result;
                        if (result2.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var item in result2.Errors)
                            {
                                ModelState.AddModelError(item.Code, item.Description);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(item.Code, item.Description);
                        }
                    }
                }
                else
                {
                    var result2 = userManager.AddToRoleAsync(userExists, "admin").Result;
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result2.Errors)
                        {
                            ModelState.AddModelError(item.Code, item.Description);
                        }
                    }
                }
            }
            return View(model);
        }
        public ActionResult UserCounts()
        {

        }
    }
}

