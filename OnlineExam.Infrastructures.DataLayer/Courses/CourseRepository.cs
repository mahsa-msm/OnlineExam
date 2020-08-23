using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Core.Courses;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Courses
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
     

        public CourseRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
           
        }

        
    }
}
