using OnlineExam.Domain.Core.Blogs;
using OnlineExam.Domain.Core.Exams;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Core.Courses
{
    public class Course : BaseEntity
    {
        [Required(ErrorMessage = "فیلد نام درس اجباری میباشد")]
        [Display(Name = "نام درس")]
        public string Name { get; set; }
        [Display(Name = "توضیحات درس ")]
        public string Description { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
