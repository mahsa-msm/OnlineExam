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

        public List<ExamQuestion> GetAllQuestion(int examId)
        {
            List<ExamQuestion> examQuestions = dbContext.ExamQuestions.Where(c => c.ExamId == examId).ToList();
            return examQuestions; 
        }
    }
}
