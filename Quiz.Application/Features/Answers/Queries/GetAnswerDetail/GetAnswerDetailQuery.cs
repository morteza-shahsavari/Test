using MediatR;
using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Queries.GetAnswerDetail
{
    public class GetAnswerDetailQuery:IRequest<AnswerListVm>
    {
        public int Id { get; set; }
    }
}
