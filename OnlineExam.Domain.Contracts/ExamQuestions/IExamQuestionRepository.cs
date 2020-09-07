using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core.ExamQuestions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Contracts.ExamQuestions
{
  public  interface IExamQuestionRepository: IBaseRepository<ExamQuestion>
    {
        List<ExamQuestion> GetExamQuestions(int examId);

    }
}
