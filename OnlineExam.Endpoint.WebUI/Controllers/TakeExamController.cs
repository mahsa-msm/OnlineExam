using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.Results;
using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
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
        private readonly ICourseRepository courseRepository;
        public TakeExamController(
           UserManager<AppUser> userManager,
           IExamQuestionRepository examQuestionRepository,
           IAnswerRepository answerRepository,
           IChoiceRepository choiceRepository,
           IResultRepository resultRepository,
           IExamRepository examRepository,
             ICourseRepository courseRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.userManager = userManager;
            this.answerRepository = answerRepository;
            this.choiceRepository = choiceRepository;
            this.resultRepository = resultRepository;
            this.examRepository = examRepository;
            this.courseRepository = courseRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TakeExam(int examID)
        {
            TakeExamViewModel takeExam = new TakeExamViewModel();
            var Exam = examRepository.Get(examID);
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();

            if (takeExam.Questions.Count == 0)
            {
                return RedirectToAction("NotExistExam");
            }
            takeExam.ExamId = examID;
            takeExam.ExamDuration = Exam.Duration;
            int startDateCompare = DateTime.Compare(Exam.StartDate, DateTime.Now);
            int endDateCompare = DateTime.Compare(Exam.EndDate, DateTime.Now);

            if (startDateCompare < 0 && endDateCompare > 0)
            {
                return RedirectToAction("NotExistExam");
            }
            return View(takeExam);
        }
        [HttpPost]
        public IActionResult TakeExam(TakeExamViewModel giveExamViewModel)
        {
            var questions = examQuestionRepository.GetExamQuestions(giveExamViewModel.ExamId).Select(c => c.Question).Select(c => c.QuestionChoices.Select(v => v.Choice.IsCorrect)).ToList();
            int score = 0;
            var user = userManager.GetUserId(User);
            try
            {
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
            }
            catch
            {
                return NotFound();
            }

            double resultScore = Math.Round((((double)score / (double)questions.Count) * 100), 2);

            Result result = new Result
            {
                AppUserId = int.Parse(user),
                ExamId = giveExamViewModel.ExamId,
                Score = resultScore,
                Exam = examRepository.Get(giveExamViewModel.ExamId),
                dateTime = DateTime.Now

            };
            resultRepository.Add(result);
            return RedirectToAction("FinishExam", new { ResultId = result.Id });

        }
        public IActionResult FinishExam(int ResultId)
        {
            Result examResult = resultRepository.Get(ResultId);
            examResult.Exam = examRepository.Get(examResult.ExamId);
            if (examResult.Score > 80)
            {
                ViewBag.Score = "good";
            }
            else if (examResult.Score < 80 && examResult.Score > 40)
            {
                ViewBag.Score = "medium";
            }
            else
            {
                ViewBag.Score = "bad";
            }
            return View(examResult);
        }
        public IActionResult NotExistExam()
        {

            return View();
        }
        public ActionResult ExamResults()
        {
            var user = userManager.GetUserId(User);
            List<ExamResultsViewModel> examResults = new List<ExamResultsViewModel>();

            var Results = resultRepository.GetAll().Where(c => c.AppUserId == int.Parse(user)).ToList();

            foreach (var result in Results)
            {
                var examId = result.ExamId;
                var courseId = examRepository.Get(result.ExamId).CourseId;

                ExamResultsViewModel examResult = new ExamResultsViewModel
                {
                    ExamName = examRepository.Get(examId).Name,
                    CourseName = courseRepository.Get(courseId).Name,
                    Score = result.Score,
                    DateTime = result.dateTime
                };

                examResults.Add(examResult);
            }

            return View(examResults);
        }

        public ActionResult AllExamResultsForAdmin()
        {

            return View();
        }

        public ActionResult AllExamResultsForAdminDataTable()
        {
            List<ExamResultsViewModel> examResults = new List<ExamResultsViewModel>();

            var Results = resultRepository.GetAll().ToList();


            foreach (var result in Results)
            {
                var examId = result.ExamId;
                var courseId = examRepository.Get(result.ExamId).CourseId;
                var user = userManager.FindByIdAsync(result.AppUserId.ToString()).Result;

                ExamResultsViewModel examResult = new ExamResultsViewModel
                {
                    UserName = user.UserName,
                    ExamName = examRepository.Get(examId).Name,
                    CourseName = courseRepository.Get(courseId).Name,
                    Score = result.Score,
                    DateTime = result.dateTime

                };
                examResults.Add(examResult);
            }

            return Json(new { data = examResults });

        }


    }
}