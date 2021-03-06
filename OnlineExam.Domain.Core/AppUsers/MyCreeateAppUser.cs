﻿using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Core.AppUsers
{
    public class MyCreeateAppUser
    {
        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        [MaxLength(50)]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        [Display(Name = " ایمیل")]
        public string Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "فیلد اجباری میباشد")]

        public string Password { get; set; }
    }

}
