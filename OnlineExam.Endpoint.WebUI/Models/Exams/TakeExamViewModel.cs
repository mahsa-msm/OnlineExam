using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.Questions;
using System.Collections.Generic;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class TakeExamViewModel
    {
        public List<Question> Questions { get; set; }
        public List<Choice> Choices { get; set; }
        public List<Answer> Answers { get; set; }
        public int ExamId { get; set; }
        public int ExamDuration { get; set; }

    }

}
