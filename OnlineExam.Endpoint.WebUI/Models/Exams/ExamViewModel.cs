using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام آزمون")]
        [Required(ErrorMessage ="فیلد اجباری است")]
        public string Name { get; set; }
        [Display(Name = "تاریخ شروع")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public DateTime EndDate { get; set; }
        [Display(Name = "زمان امتحان ")]
        [Required(ErrorMessage = "فیلد اجباری است")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "فیلد اجباری است")]
        public int CourseId { get; set; }


    }
}
