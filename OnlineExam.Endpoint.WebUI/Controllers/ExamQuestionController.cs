using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class ExamQuestionController : Controller
    {
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IExamRepository examRepository;
        private readonly IQuestionRepository questionRepository;

        public ExamQuestionController(IExamQuestionRepository examQuestionRepository , IExamRepository examRepository,IQuestionRepository questionRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
        }
        public IActionResult Index(int examId)
        {
            List<ExamQuestion> examQuestions = examQuestionRepository.GetAllQuestion(examId);
            ViewBag.Exam = examRepository.Get(examId);
            return View(examQuestions);
        }


        public IActionResult AddQuestion(int examId)
        {
            ViewBag.Exam = examRepository.Get(examId) ;
            return View();
        }
        //[HttpPost]
        //public IActionResult AddQuestion(int examId , AddQuestionViewModel questionViewModel)
        //{
        //    Exam exam = examRepository.Get(examId);

        //    if (ModelState.IsValid)
        //    {
        //        questionRepository.Add(questionViewModel);
        //        examQuestionRepository.Add(
        //        new ExamQuestion
        //        {
        //            ExamId = examId,
        //            QuestionId = questionViewModel.Id,
        //            Exam = exam,
        //            Question = questionViewModel
        //        }
        //        );
        //        return RedirectToAction("Index", new { examId = examId });
        //    }

        //    return View();
        //}


    }
}