using OnlineExam.Domain.Core.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Core.Answers
{
   public class Answer:BaseEntity
    {
        public int UserId { get; set; }
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }
        //public AppUser AppUser { get; set; }

    }
}
