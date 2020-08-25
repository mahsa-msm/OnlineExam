using OnlineExam.Domain.Contracts.Common;
using OnlineExam.Domain.Core.QuestionChoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Domain.Contracts.QuestionChoices
{
   public interface IQuestionChoiceRepository: IBaseRepository<QuestionChoice>
    {
        List<QuestionChoice> GetQuestionChoices(int questionID);
    }
    
}
