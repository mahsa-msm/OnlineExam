using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class AddQuestionViewModel
    {
        public int ExamId { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
    }
}
