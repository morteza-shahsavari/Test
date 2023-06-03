using MediatR;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Queries.GetQuestionQueryListPaging
{
    public class GetQuestionQueryListPaging:IRequest<QuestionPageListVm>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
