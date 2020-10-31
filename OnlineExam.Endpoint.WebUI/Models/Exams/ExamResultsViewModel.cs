using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class ExamResultsViewModel
    {
        [Display(Name = "نام کاربر")]
        public string UserName { get; set; }
        [Display(Name = "نام آزمون")]

        public string ExamName{ get; set; }
        [Display(Name = "نام درس ")]

        public string CourseName { get; set; }
        [Display(Name = "نمره")]

        public double Score { get; set; }
        [Display(Name = "تاریخ ")]

        public DateTime DateTime { get; set; }

    }
}
