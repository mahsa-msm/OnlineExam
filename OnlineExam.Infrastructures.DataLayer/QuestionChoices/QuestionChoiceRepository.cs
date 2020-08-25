
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.QuestionChoices
{
    public class QuestionChoiceRepository : BaseRepository<QuestionChoice>, IQuestionChoiceRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public QuestionChoiceRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Question> GetQuestionChoices(int questionID)
        {
            return dbContext.Questions.Include(x=>x.QuestionChoices).ThenInclude(c => c.Choice).ToList();

        }

        List<QuestionChoice> IQuestionChoiceRepository.GetQuestionChoices(int questionID)
        {
            throw new NotImplementedException();
        }
    }
   
}
