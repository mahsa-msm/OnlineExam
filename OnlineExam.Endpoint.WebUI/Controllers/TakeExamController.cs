using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class TakeExamController : Controller
    {
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IExamRepository examRepository;
        private readonly IAnswerRepository answerRepository;
        private readonly IChoiceRepository choiceRepository;

        public TakeExamController(IExamQuestionRepository examQuestionRepository,
            IQuestionRepository questionRepository,
            IExamRepository examRepository,
             IAnswerRepository answerRepository,
             IChoiceRepository  choiceRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.questionRepository = questionRepository;
            this.examRepository = examRepository;
            this.answerRepository = answerRepository;
            this.choiceRepository = choiceRepository;
        }
        public IActionResult Index(int examID)
        {

            GiveExamViewModel takeExam = new GiveExamViewModel();
            takeExam.ExamId = examID;
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();

            return View(takeExam);
        }


        public IActionResult TakeExam2(int examID, int userId)
        {
            TakeExamViewModel takeExam = new TakeExamViewModel();
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();
            takeExam.ExamId = examID;

            return View(takeExam);
        }
        [HttpPost]

        public IActionResult TakeExam2(TakeExamViewModel giveExamViewModel)
        {

            var Choice = examQuestionRepository.GetExamQuestions(giveExamViewModel.ExamId).Select(c => c.Question).Select(c => c.QuestionChoices.Select(v => v.Choice.IsCorrect)).ToList();
            int score = 0;
            foreach (var item in giveExamViewModel.Answers)
            {
                Answer answer = new Answer
                {
                    ChoiceId = item.ChoiceId,
                    IsSelected = item.IsSelected,

                };
                answerRepository.Add(answer);
                var choice = choiceRepository.Get(item.ChoiceId);
                if (item.IsSelected == choice.IsCorrect)
                {
                    score++;
                }
            }

            


            return RedirectToAction("Index");


        }

    }
}