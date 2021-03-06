﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.Blogs;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Endpoint.WebUI.Models.UserApp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.MVC.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<MyIdentityRole> roleManager;
        private readonly IBlogRepository blogRepository;

        public UserAccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signInMgr, RoleManager<MyIdentityRole> roleManager,
        IBlogRepository BlogRepository
  )
        {
            userManager = userMgr;
            signInManager = signInMgr;
            this.roleManager = roleManager;
            blogRepository = BlogRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Blogs = blogRepository.GetAll().OrderByDescending(x => x.Id);
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

                        return RedirectToAction("Login");
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

        //   [Authorize(Roles = "admin")]
        public IActionResult Role()
        {
            MyIdentityRole role = new MyIdentityRole
            {
                Name = "admin"
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

            var data = userManager.Users.Count();
            return Json(new { data });
        }
        public async Task<ActionResult> AdminCounts()
        {

            int counts = 0;
            foreach (var user in userManager.Users.ToList())
            {
                if (user != null && await userManager.IsInRoleAsync(user, "admin"))
                    counts++;
            }
            return Json(new { data = counts });

        }

        public async Task<ActionResult> AdminsDataTable()
        {
            List<AppUser> admins = new List<AppUser>();

            foreach (var user in userManager.Users.ToList())
            {
                if (user != null && await userManager.IsInRoleAsync(user, "admin"))
                    admins.Add(user);
            }
            return Json(new { data = admins });
        }
        public ActionResult UserList()
        {
            return View();
        }
        public ActionResult UsersDataTable()
        {
            List<AppUser> admins = new List<AppUser>();

            foreach (var user in userManager.Users.ToList())
            {
                admins.Add(user);
            }
            return Json(new { data = admins });
        }
        public async Task<ActionResult> DeleteUser(int id)
        {

            var user = await userManager.FindByIdAsync(id.ToString());
            var roles = await userManager.GetRolesAsync(user);
            IdentityResult result;
            foreach (var role in roles)
            {
                result = await userManager.RemoveFromRoleAsync(user, role);
            }
            
            result = await userManager.DeleteAsync(user);

            return RedirectToAction("UserList");
        }
    }
}

