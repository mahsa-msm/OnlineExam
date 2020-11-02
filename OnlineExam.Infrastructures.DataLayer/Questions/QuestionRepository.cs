using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Infrastructures.DataLayer.Common;

namespace OnlineExam.Infrastructures.DataLayer.Questions
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public QuestionRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
