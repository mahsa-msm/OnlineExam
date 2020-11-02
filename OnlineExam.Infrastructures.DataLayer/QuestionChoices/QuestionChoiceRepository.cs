using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Infrastructures.DataLayer.Common;

namespace OnlineExam.Infrastructures.DataLayer.QuestionChoices
{
    public class QuestionChoiceRepository : BaseRepository<QuestionChoice>, IQuestionChoiceRepository
    {
        public QuestionChoiceRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
        }

    }
}
