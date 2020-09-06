using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Core.Courses;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Courses
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly OnlineExamDbContext _dbContext;

        public CourseRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
           _dbContext = dbContext;
        }

        //public void GetResult(int examId)
        //{
        //    var exam = _dbContext.Courses
        //    .Include(c => c.Exams).ThenInclude(d => d.ExamQuestions).ThenInclude(x => x.Question).ThenInclude(g => g.QuestionChoices).ThenInclude(m => m.Choice);
        //}

    }
}
