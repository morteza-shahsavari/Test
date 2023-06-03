using MediatR;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQuery:IRequest<List<QuestionListVm>>
    {
        public int Id { get; set; }
    }
}
