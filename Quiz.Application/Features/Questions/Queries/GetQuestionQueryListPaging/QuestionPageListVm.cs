using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Queries.GetQuestionQueryListPaging
{
    public class QuestionPageListVm
    {
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public ICollection<QuestionListVm>? QuestionListVm { get; set; }
    }
}
