using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Endpoint.WebUI.Models.UserApp
{
    public class CreateUserViewModel
    {

        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        [MaxLength(50)]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "فیلد اجباری میباشد")]

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage ="ایمیل نامعتبر میباشد")]
        public string Email { get; set; }
        [Required(ErrorMessage = "فیلد اجباری میباشد")]
        [MaxLength(50)]
        [Display(Name = "رمز عبور")]

        public string Password { get; set; }
    }
}

