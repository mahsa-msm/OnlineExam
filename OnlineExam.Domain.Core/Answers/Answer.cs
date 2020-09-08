using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Domain.Core.Choices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineExam.Domain.Core.Answers
{
    public class Answer : BaseEntity
    {
        public int AppUserId { get; set; }
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }
        public virtual AppUser AppUser { get; set; }
        public bool IsSelected { get; set; }

    }
}
