using OnlineExam.Domain.Core.Courses;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Core.Exams
{
    public class Exam : BaseEntity
    {
        [Display(Name = "نام آزمون")]
        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        public string Name { get; set; }
        [Display(Name = "تاریخ شروع")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public DateTime EndDate { get; set; }
        [Display(Name = "زمان امتحان (دقیقه) ")]
        public int Duration { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Result> Results { get; set; }


    }
}
