using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Infrastructures.DataLayer.Common;

namespace OnlineExam.Infrastructures.DataLayer.Choices
{
    public class ChoiceRepository : BaseRepository<Choice>, IChoiceRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public ChoiceRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        //public List<Exam> GetALlChoice(int examId)
        //{
        //return    dbContext.Choices.Include(c => c.QuestionChoice).ThenInclude(d => d.Question).ThenInclude(x => x.ExamQuestions).ThenInclude(g => g.Exam).ToListAsync();

        //}
    }
}
