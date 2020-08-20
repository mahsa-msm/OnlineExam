using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.ExamQuestions
{
    public class ExamQuestionRepository : BaseRepository<ExamQuestion>, IExamQuestionRepository
    {
        public ExamQuestionRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {

        }
    }
}
