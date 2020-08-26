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
        private readonly IAnswerRepository answerRepository;

        public TakeExamController(IExamQuestionRepository examQuestionRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
        }
        public IActionResult Index(int examID)
        {

            TakeExamViewModel takeExam = new TakeExamViewModel();
            takeExam.ExamId = examID;
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();

            return View(takeExam);
        }
    }
}