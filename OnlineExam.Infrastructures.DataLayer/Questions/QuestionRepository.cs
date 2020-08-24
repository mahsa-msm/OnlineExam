using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
