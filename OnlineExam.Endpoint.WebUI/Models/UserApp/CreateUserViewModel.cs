using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Endpoint.WebUI.Models.UserApp
{
    public class CreateUserViewModel
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

