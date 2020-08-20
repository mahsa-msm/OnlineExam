using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Questions
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
