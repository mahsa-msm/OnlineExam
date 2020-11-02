using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.QuestionChoices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Core.Choices
{
    public class Choice : BaseEntity
    {
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public virtual ICollection<QuestionChoice> QuestionChoice { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
