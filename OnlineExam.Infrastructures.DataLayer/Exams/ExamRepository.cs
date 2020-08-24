using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Exams
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public ExamRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Exam> GetAllCourses(int id)
        {
            var CourseExam = dbContext.Exams.Where(c => c.CourseId == id).ToList();
            return CourseExam;
        }

        public List<Exam> GetExams()
        {

            return dbContext.Exams.Include(c => c.ExamQuestions).ThenInclude(c => c.Question).ToList();

        }
    }
}
