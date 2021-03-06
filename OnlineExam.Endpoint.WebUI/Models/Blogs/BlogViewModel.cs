﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Blogs
{
    public class BlogViewModel
    {
        [Required]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "توضیحات ")]
        [MaxLength(200,ErrorMessage ="تعداد کاراکتر مجاز 200 است ")]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CourseId { get; set; }
    }
}
