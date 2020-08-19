using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExam.Domain.Core.ExamQuestions
{
  public  class ExamQuestion:BaseEntity
    {
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public virtual Question Question { get; set; }
        
        public virtual Exam Exam { get; set; }
    }
}
