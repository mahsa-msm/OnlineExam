﻿using OnlineExam.Domain.Core.Exams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExam.Domain.Core.Courses
{
    public class Course : BaseEntity
    {
        [Required(ErrorMessage = "فیلد نام درس اجباری میباشد")]
        [Display(Name ="نام درس")]
        public string Name { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
