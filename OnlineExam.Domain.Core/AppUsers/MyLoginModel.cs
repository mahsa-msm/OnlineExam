using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExam.Domain.Core.AppUsers
{
   public class MyLoginModel
    {
        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        [Display(Name = "نام کاربر")]
        public string Name { get; set; }
        [Required(ErrorMessage ="فیلد اجباری میباشد")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/UserAccount/";
    }
}
