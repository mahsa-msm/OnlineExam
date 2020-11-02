using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.QuestionChoices;
using System.Collections.Generic;

namespace OnlineExam.Domain.Core.Questions
{
    public class Question : BaseEntity
    {

        public string Text { get; set; }

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }


    }
}
