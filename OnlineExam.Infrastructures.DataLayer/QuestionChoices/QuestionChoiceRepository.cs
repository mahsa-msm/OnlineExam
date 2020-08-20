
using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.QuestionChoices
{
    public class QuestionChoiceRepository : BaseRepository<QuestionChoice>, IQuestionChoiceRepository
    {
        public QuestionChoiceRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {

        }
    }
}
