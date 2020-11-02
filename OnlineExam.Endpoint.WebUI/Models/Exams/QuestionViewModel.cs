using OnlineExam.Domain.Core.Choices;
using System.Collections.Generic;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class QuestionViewModel
    {
        public int ExamId { get; set; }
        public int ExamName { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
