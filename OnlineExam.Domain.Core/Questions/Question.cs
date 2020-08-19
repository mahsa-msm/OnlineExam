using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.QuestionChoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Core.Questions
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }


    }
}
