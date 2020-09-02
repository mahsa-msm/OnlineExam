using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class GiveExamViewModel
    {
        public int AppUser { get; set; }
        public List<Question> Questions { get; set; }
        public int ExamId { get; set; }

    }
}
