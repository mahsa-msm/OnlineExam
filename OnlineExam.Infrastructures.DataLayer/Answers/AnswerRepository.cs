using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Core.Answers;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Answers
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {

        }
    }
}
