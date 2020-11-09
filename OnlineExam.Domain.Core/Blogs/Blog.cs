using OnlineExam.Domain.Core.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExam.Domain.Core.Blogs
{
    public class Blog:BaseEntity
    {
        [Required]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "توضحیات ")]
        public string Description { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
