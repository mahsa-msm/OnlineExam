using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class ExamQuestionController : Controller
    {
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IExamRepository examRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IQuestionChoiceRepository questionChoiceRepository;
        private readonly IChoiceRepository choiceRepository;

        public ExamQuestionController(IExamQuestionRepository examQuestionRepository
            , IExamRepository examRepository
            , IQuestionRepository questionRepository
            , IQuestionChoiceRepository questionChoiceRepository,
            IChoiceRepository choiceRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
            this.questionChoiceRepository = questionChoiceRepository;
            this.choiceRepository = choiceRepository;
        }
        public IActionResult Index(int examId)
        {
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examId);
            //List<QuestionChoice> questionChoices =questionChoiceRepository.GetQuestionChoices()
            ViewBag.Exam = examRepository.Get(examId);
            ViewBag.ExamId = examId;
            return View(examQuestions);
        }


        public IActionResult AddQuestion(int examId)
        {
            ViewBag.Exam = examRepository.Get(examId);
            return View();
        }
        [HttpPost]
        public   IActionResult AddQuestion(QuestionViewModel questionViewModel)
        {
            Exam exam =  examRepository.Get(questionViewModel.ExamId);

            if (ModelState.IsValid)
            {
                Question qusetion = new Question
                {
                    Text = questionViewModel.Text
                };
                questionRepository.Add(qusetion);
                ExamQuestion examQuestion = new ExamQuestion
                {
                    ExamId = questionViewModel.ExamId,
                    QuestionId = qusetion.Id,
                    Exam = exam,
                    Question = qusetion
                };

                for(int i = 0; i<4; i++)
                {
                    Choice  choice = questionViewModel.Choices[i];
                    choiceRepository.Add(choice);

                   QuestionChoice questionChoice = new QuestionChoice
                    {
                       
                        Question = qusetion,
                        Choice = choice , 
                        ChoiceId = choice.Id,
                       QuestionId = qusetion.Id,


                   };
                    questionChoiceRepository.Add(questionChoice);

                }

                examQuestionRepository.Add(examQuestion);


                return RedirectToAction("Index", new { examId = questionViewModel.ExamId });
            }

            return View();
        }


    }
}