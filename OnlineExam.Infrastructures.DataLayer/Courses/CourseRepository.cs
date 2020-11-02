using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Core.Courses;
using OnlineExam.Infrastructures.DataLayer.Common;

namespace OnlineExam.Infrastructures.DataLayer.Courses
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly OnlineExamDbContext _dbContext;

        public CourseRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
