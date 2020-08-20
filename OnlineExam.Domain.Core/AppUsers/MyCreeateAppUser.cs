using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExam.Domain.Core.AppUsers
{
   public class MyCreeateAppUser
    {
        [Required(ErrorMessage = "فیلد اجباری است")]
        [MaxLength(50)]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required]

        [Display(Name = "ایمیل")]

        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "رمز عبور")]

        public string Password { get; set; }
    }

}
