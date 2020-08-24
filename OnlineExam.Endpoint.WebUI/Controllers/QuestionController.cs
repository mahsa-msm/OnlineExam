using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.ExamQuestions;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IExamRepository examRepository;

        public QuestionController(IExamQuestionRepository examQuestionRepository, IExamRepository examRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.examRepository = examRepository;

        }
      
    }
}