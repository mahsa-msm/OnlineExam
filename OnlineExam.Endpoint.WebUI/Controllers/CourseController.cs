using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Core.Courses;
using System.Linq;

namespace OnlineExam.Endpoint.WebUI.Controllers
{

    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var courses = courseRepository.GetAll().ToList();
            return View(courses);
        }

        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {

                courseRepository.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            courseRepository.Delete(id);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "admin")]
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
                if (model.Id == 0)
                {
                    courseRepository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {

                    courseRepository.Update(model);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }



        public IActionResult GetDataTableCourse()
        {
            var course = courseRepository.GetAll().ToList();
            return Json(new { data = course });
        }

    }
}