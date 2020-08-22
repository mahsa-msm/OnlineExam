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
        public IActionResult Index()
        {
            var model = examRepository.GetAll().ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int courseId)
        {
            ViewBag.courseId = courseId;
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
                    

                };
                examRepository.Add(exam); 

              
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}