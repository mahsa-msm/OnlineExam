using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Blogs;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Domain.Core.Blogs;
using OnlineExam.Endpoint.WebUI.Models.Blogs;

namespace OnlineExam.Endpoint.WebUI.Controllers
{

    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ICourseRepository courseRepository;
        private readonly IBlogRepository BlogRepository;
        public BlogController(IBlogRepository BlogRepository , UserManager<AppUser> userManager , ICourseRepository courseRepository)
        {
            this.userManager = userManager;
            this.courseRepository = courseRepository;
            this.BlogRepository = BlogRepository;
        }
        public IActionResult Index()
        {
            var Blogs = BlogRepository.GetAll().ToList();
            return View(Blogs);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create(int courseId)
        {
            ViewBag.Course = courseRepository.Get(courseId);
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog
                {
                    Description=model.Description,
                    CourseId = model.CourseId,
                    CreateDate = DateTime.Now,
                    ImageName = model.ImageName,
                    Title = model.Title,
                    CreateBy = userManager.GetUserName(User)
                };

                BlogRepository.Add(blog);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            BlogRepository.Delete(id);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            Blog Blog = BlogRepository.Get(id);
            return View(Blog);
        }

        [HttpPost]
        public IActionResult Update(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    BlogRepository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {

                    BlogRepository.Update(model);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

    }
}