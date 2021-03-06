﻿using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Infrastructures.DataLayer.Common;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExam.Infrastructures.DataLayer.Exams
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        private readonly OnlineExamDbContext dbContext;

        public ExamRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Exam> GetAllExams(int id)
        {
            var CourseExam = dbContext.Exams.Where(c => c.CourseId == id).ToList();
            return CourseExam;
        }
    }
}
