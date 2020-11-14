using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IBlogRepository blogRepository;
        public BlogController(IBlogRepository BlogRepository, UserManager<AppUser> userManager, ICourseRepository courseRepository)
        {
            this.userManager = userManager;
            this.courseRepository = courseRepository;
            this.blogRepository = BlogRepository;
        }
        public IActionResult Index(int courseId = 0)
        {
            if (courseId == 0)
            {
                var Blogs = blogRepository.GetAll().OrderByDescending(x => x.Id).ToList();
               
                return View(Blogs);
            }
            else
            {
                ViewBag.courseId = courseId;
               var Blogs = blogRepository.GetAll().OrderByDescending(x => x.Id).Where(c => c.CourseId == courseId).ToList();
                return View(Blogs);
            }
        }


        [Authorize(Roles = "admin")]
        public IActionResult Create(int courseId)
        {
            ViewBag.Course = courseRepository.Get(courseId);
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogViewModel model, IFormFile file)
        {
            Random randomNumber = new Random();
            string ImageName = randomNumber.Next(11111, 99999) + file.FileName;

            if (ModelState.IsValid)
            {
                Blog blog = new Blog
                {
                    Description = model.Description,
                    CourseId = model.CourseId,
                    CreateDate = DateTime.Now,
                    ImageName = ImageName,
                    Title = model.Title,
                    CreateBy = userManager.GetUserName(User)
                };

                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/BlogImages", ImageName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                blogRepository.Add(blog);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            blogRepository.Delete(id);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            Blog Blog = blogRepository.Get(id);
            return View(Blog);
        }

        [HttpPost]
        public IActionResult Update(Blog model, IFormFile file)
        {
            Random randomNumber = new Random();
            string ImageName = randomNumber.Next(11111, 99999) + file.FileName;

            var blog = blogRepository.Get(model.Id);
            blog.ImageName = ImageName;
            blog.Description = model.Description;
            blog.CreateDate = DateTime.Now;
            blog.Title = model.Title;


            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/BlogImages", ImageName);

            using (var stream = new FileStream(SavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            blogRepository.Update(blog);

            return RedirectToAction("Index");


        }

    }
}