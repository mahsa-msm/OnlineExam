using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Contracts.Results;
using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Domain.Core.Results;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class TakeExamController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IAnswerRepository answerRepository;
        private readonly IChoiceRepository choiceRepository;
        private readonly IResultRepository resultRepository;
        private readonly IExamRepository examRepository;

        public TakeExamController(
           UserManager<AppUser> userManager,
           IExamQuestionRepository examQuestionRepository,
           IAnswerRepository answerRepository,
           IChoiceRepository choiceRepository,
           IResultRepository resultRepository,
           IExamRepository examRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.userManager = userManager;
            this.answerRepository = answerRepository;
            this.choiceRepository = choiceRepository;
            this.resultRepository = resultRepository;
            this.examRepository = examRepository;
        }
        //public IActionResult Index(int examID)
        //{

        //    GiveExamViewModel takeExam = new GiveExamViewModel();
        //    takeExam.ExamId = examID;
        //    List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
        //    takeExam.Questions = examQuestions.Select(c => c.Question).ToList();

        //    return View(takeExam);
        //}


        public IActionResult TakeExam2(int examID)
        {
            TakeExamViewModel takeExam = new TakeExamViewModel();
           var Exam= examRepository.Get(examID);
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();
            takeExam.ExamId = examID;
            takeExam.ExamDuration = Exam.Duration;
            return View(takeExam);
        }
        [HttpPost]

        public IActionResult TakeExam2(TakeExamViewModel giveExamViewModel)
        {
            var questions = examQuestionRepository.GetExamQuestions(giveExamViewModel.ExamId).Select(c => c.Question).Select(c => c.QuestionChoices.Select(v => v.Choice.IsCorrect)).ToList();
            int score = 0;
            var user = userManager.GetUserId(User);

            foreach (var item in giveExamViewModel.Answers)
            {
                Answer answer = new Answer
                {
                    AppUserId = int.Parse(user),
                    ChoiceId = item.ChoiceId,
                    IsSelected = item.IsSelected

                };
                answerRepository.Add(answer);
                var choice = choiceRepository.Get(item.ChoiceId);
                if (item.IsSelected == true && choice.IsCorrect == true)
                {
                    score++;
                }
            }

            double resultScore = Math.Round((((double)score / (double)questions.Count) * 100),2);
            
            Result result = new Result
            {
                AppUserId = int.Parse(user),
                ExamId = giveExamViewModel.ExamId,
                Score = resultScore
            };
            resultRepository.Add(result);


            return RedirectToAction("Index");


        }

    }
}