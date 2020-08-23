using System;
using System.Collections.Generic;
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
          List<Exam> model =   examRepository.GetAllCourses(courseId);
            return View(model);
        
        }

        [HttpGet]
        public IActionResult Create(int courseId)
        {
          var course =   courseRepository.Get(courseId);



            ViewBag.Course= courseRepository.Get(courseId); 
          
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExamViewModel model)
        {
         
            if (ModelState.IsValid)
            {
                Exam exam = new Exam
                {
                    Name = model.Name,
                    Duration = model.Duration,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CourseId=model.CourseId

                };
                examRepository.Add(exam); 

              
                return RedirectToAction("Index" , new { courseId = model.CourseId });
            }
            return View();
        }


    }
}