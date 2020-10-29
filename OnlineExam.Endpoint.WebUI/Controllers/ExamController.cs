using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Core.Courses;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamRepository examRepository;
        private readonly ICourseRepository courseRepository;

        public ExamController(IExamRepository examRepository, ICourseRepository courseRepository)
        {
            this.examRepository = examRepository;
            this.courseRepository = courseRepository;

        }
        public IActionResult Index(int courseId)
        {
            List<Exam> model = examRepository.GetAllCourses(courseId);
            ViewBag.Course = courseRepository.Get(courseId);
            return View(model);

        }

        [HttpGet]
        public IActionResult Create(int courseId)
        {
            ViewBag.Course = courseRepository.Get(courseId);
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExamViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                if (model.StartDate == null)
                    model.StartDate = DateTime.Now;

                Exam exam = new Exam
                {
                    Name = model.Name,
                    Duration = model.Duration,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CourseId = model.CourseId

                };
                examRepository.Add(exam);
                return RedirectToAction("Index", new { courseId = model.CourseId });
            }
            return View();
        }
        [HttpGet]
        public  IActionResult Update(int courseId, int examId)
        {

            Exam exam =  examRepository.Get(examId);
            ExamViewModel model = new ExamViewModel
            {
                CourseId = courseId,
                Duration = exam.Duration,
                EndDate = exam.EndDate,
                StartDate = exam.StartDate,
                Name = exam.Name,
                Id = exam.Id
            };

            ViewBag.Course = courseRepository.Get(courseId);
            ViewBag.examId = courseRepository.Get(examId);
            return View(model);
        }

        [HttpPost]
        public  IActionResult Update(ExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.StartDate == null)
                    model.StartDate = DateTime.Now;
                Exam exam =  examRepository.Get(model.Id);

                exam.Name = model.Name;
                exam.StartDate = model.StartDate;
                exam.EndDate = model.EndDate;
                exam.Duration = model.Duration;
                examRepository.Update(exam);
                return RedirectToAction("Index", new { courseId = model.CourseId });
            }
            return View();
        }

        public IActionResult Delete(int id, int courseId)
        {
            examRepository.Delete(id);
            return RedirectToAction("Index", new { courseId });
        }
    }
}