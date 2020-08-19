using OnlineExam.Domain.Core.Exams;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Core.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
