using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Choices
{
    public class ChoiceRepository : BaseRepository<Choice>, IChoiceRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public ChoiceRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        
    }
}
