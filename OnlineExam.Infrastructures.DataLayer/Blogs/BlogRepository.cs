using OnlineExam.Domain.Contracts.Blogs;
using OnlineExam.Domain.Core.Blogs;
using OnlineExam.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Blogs
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
