using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.Questions;

namespace OnlineExam.Domain.Core.QuestionChoices
{
    public class QuestionChoice : BaseEntity
    {

        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public virtual Question Question { get; set; }

        public virtual Choice Choice { get; set; }



    }
}
