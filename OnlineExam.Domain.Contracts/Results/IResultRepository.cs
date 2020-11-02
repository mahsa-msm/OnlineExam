using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Contracts.Results
{
    public interface IResultRepository : IBaseRepository<Result>
    {
        Task<List<Result>> GetAllResultUser(int userId);
    }
}
