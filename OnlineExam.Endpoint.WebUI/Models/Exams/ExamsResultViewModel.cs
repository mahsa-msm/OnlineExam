using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Endpoint.WebUI.Models.Exams
{
    public class ExamsResultViewModel
    {
        public int AppUserId { get; set; }
        public Task<List<Result>> Result { get; set; }
    }
}
