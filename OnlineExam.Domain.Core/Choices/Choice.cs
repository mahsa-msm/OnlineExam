using System;
using System.Collections.Generic;
using System.Text;
using OnlineExam.Domain.Core;
using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Domain.Core.Questions;

namespace OnlineExam.Domain.Core.Choices
{
    public class Choice : BaseEntity
    {
        public string Text { get; set; }
        public virtual ICollection<QuestionChoice> QuestionChoice { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
