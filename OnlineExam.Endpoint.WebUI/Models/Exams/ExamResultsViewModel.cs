using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class ExamResultsViewModel
    {
        public string UserName { get; set; }
        public string ExamName{ get; set; }
        public string CourseName { get; set; }
        public double Score { get; set; }
        public DateTime DateTime { get; set; }

    }
}
