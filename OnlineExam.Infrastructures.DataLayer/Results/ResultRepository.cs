using OnlineExam.Domain.Contracts.Results;
using OnlineExam.Domain.Core.Results;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Results
{
    public class ResultRepository : BaseRepository<Result>,IResultRepository
    {
        public ResultRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
