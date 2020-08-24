using OnlineExam.Domain.Core.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class QuestionViewModel
    {
        public int ExamId { get; set; }
        public int ExamName { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public List<Question> questions { get; set; }
    }
}
