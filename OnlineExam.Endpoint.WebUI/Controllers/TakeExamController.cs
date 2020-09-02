using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class TakeExamController : Controller
    {
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IExamRepository examRepository;
        private readonly IAnswerRepository answerRepository;

        public TakeExamController(IExamQuestionRepository examQuestionRepository,
            IQuestionRepository questionRepository,
            IExamRepository examRepository ,
             IAnswerRepository answerRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.questionRepository = questionRepository;
            this.examRepository = examRepository;
            this.answerRepository = answerRepository;
        }
        public IActionResult Index(int examID)
        {

            GiveExamViewModel takeExam = new GiveExamViewModel();
            takeExam.ExamId = examID;
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();

            return View(takeExam);
        }


        public IActionResult TakeExam(int examID , int userId,int pagenumber=1 , int pagesize=3)
        {
            GiveExamViewModel takeExam = new GiveExamViewModel();
            ViewBag.examId = examID;
            takeExam.ExamId = examID;
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();
            return View(takeExam);
        }
      
    }
}