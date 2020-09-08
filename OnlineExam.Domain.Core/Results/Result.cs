﻿using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Domain.Core.Exams;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Core.Results
{
    public class Result:BaseEntity
    {
        public int ExamId { get; set; }
        public int AppUserId { get; set; }
        public float Score { get; set; }
        public Exam Exam { get; set; }
        public AppUser AppUser { get; set; }
    }
}
