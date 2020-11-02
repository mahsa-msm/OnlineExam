using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class ExamDateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام آزمون")]
        public string Name { get; set; }
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }
        [Display(Name = "زمان امتحان ")]
        public int Duration { get; set; }
        public int CourseId { get; set; }
    }
}
