using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core.Exams;
using System.Collections.Generic;

namespace OnlineExam.Domain.Contracts.Exams
{
    public interface IExamRepository : IBaseRepository<Exam>
    {

        List<Exam> GetAllExams(int id);
    }
}
