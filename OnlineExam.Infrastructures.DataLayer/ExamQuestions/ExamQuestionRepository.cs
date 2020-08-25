using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.ExamQuestions
{
    public class ExamQuestionRepository : BaseRepository<ExamQuestion>, IExamQuestionRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public ExamQuestionRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ExamQuestion> GetExamQuestions(int examId)
        {
            
                var exam = dbContext.ExamQuestions
                .Include(c => c.Question)
                .ThenInclude(x => x.QuestionChoices)
                .ThenInclude(a => a.Choice)
                .Where(q => q.ExamId == examId)
                .ToList();
                return exam;
           
            
        }
    }
}
