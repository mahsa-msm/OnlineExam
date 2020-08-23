using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExam.Domain.Contracts.Exams
{
  public  interface IExamRepository : IBaseRepository<Exam>
    {

        List<Exam> GetAllCourses(int id);
    }
}
