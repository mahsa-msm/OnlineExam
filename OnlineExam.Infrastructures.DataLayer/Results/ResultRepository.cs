using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.Results;
using OnlineExam.Domain.Core.Results;
using OnlineExam.Infrastructures.DataLayer.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Infrastructures.DataLayer.Results
{
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public ResultRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Result>> GetAllResultUser(int userId)
        {
            var data = dbContext.Results.Include(c => c.Exam).Include(v => v.AppUser).Where(b => b.AppUserId == userId);
            return await data.ToListAsync();

        }
    }
}
