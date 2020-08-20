using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Exams
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {

        }
    }
}
