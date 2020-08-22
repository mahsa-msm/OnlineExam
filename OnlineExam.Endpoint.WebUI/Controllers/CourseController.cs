using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Domain.Core.Courses;

namespace OnlineExam.Endpoint.WebUI.Controllers
{

    //[Authorize(Roles ="admin")]
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
       
        public CourseController(ICourseRepository courseRepository )
        {
           
            this.courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var course = courseRepository.GetAll().ToList();
            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course model)
        {
            Course course = new Course { Name = model.Name };
            courseRepository.Add(course);
            return RedirectToAction("Index");
        }
    
       
        public IActionResult Delete(int id)
        {
            courseRepository.Delete(id);
            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            Course course = courseRepository.Get(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Update(Course model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                   
                    Name = model.Name
                };
                courseRepository.Add(course);
                return RedirectToAction("Index");
            }

            return View(model);
           
   
        }


    }
}