using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Endpoint.WebUI.Models.Exams;

namespace OnlineExam.Endpoint.WebUI.Controllers
{
    public class TakeController : Controller
    {
        private readonly IExamQuestionRepository examQuestionRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IExamRepository examRepository;
        private readonly IAnswerRepository answerRepository;
        private readonly IChoiceRepository choiceRepository;
        private readonly IQuestionChoiceRepository questionChoiceRepository;

        public TakeController(IExamQuestionRepository examQuestionRepository,
            IQuestionRepository questionRepository,
            IExamRepository examRepository,
             IAnswerRepository answerRepository,
             IChoiceRepository choiceRepository,
             IQuestionChoiceRepository questionChoiceRepository)
        {
            this.examQuestionRepository = examQuestionRepository;
            this.questionRepository = questionRepository;
            this.examRepository = examRepository;
            this.answerRepository = answerRepository;
            this.choiceRepository = choiceRepository;
            this.questionChoiceRepository = questionChoiceRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetList()
        {
            //var items = courseRepository.GetAll();
            //return  Json( new { data = items });
            return View();
        }


        public JsonResult TakeExam(int examID = 1)
        {
            GiveExamViewModel takeExam = new GiveExamViewModel();
            ViewBag.examId = examID;
            takeExam.ExamId = examID;
            List<ExamQuestion> examQuestions = examQuestionRepository.GetExamQuestions(examID).ToList();
            takeExam.Questions = examQuestions.Select(c => c.Question).ToList();

            var t = takeExam.Questions.Select(x => x.QuestionChoices.Select(x => x.Choice.Text));
            //        return new JsonResult(takeExam);

            return Json(new
            {

                examName = takeExam.ExamId,
                examResponse = getExamAnswers(takeExam.ExamId),

            });
        }

        private string getExamAnswers(int examId)
        {
            var examQuestions = examQuestionRepository.GetExamQuestions(examId);

            var answers = "";

            foreach (var examQuestion in examQuestions)
            {
                answers.Concat($"{examQuestion.Question.Text} :");

                foreach (var QuestionChoice in examQuestion.Question.QuestionChoices)
                {
                    var number = 1;
                    answers.Concat($"{number.ToString()}-{QuestionChoice.Choice.Text}");
                    number++;
                }
            }

            return answers;
        }
        public ActionResult Take2()
        {
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Take2(string[] DynamicTextBox , QuestionViewModel questionViewModel)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            Question question = new Question { Text = questionViewModel.Text };
            questionRepository.Add(question);

            //Loop through the dynamic TextBox values.
            foreach (string textboxValue in DynamicTextBox)
            {
                Choice choice = new Choice { Text = textboxValue };
                choiceRepository.Add(choice);
                QuestionChoice questionChoice = new QuestionChoice
                {
                    Choice = choice,
                    Question = question
                };
                questionChoiceRepository.Add(questionChoice);

            }
            return View();
        }
   
    }
}
