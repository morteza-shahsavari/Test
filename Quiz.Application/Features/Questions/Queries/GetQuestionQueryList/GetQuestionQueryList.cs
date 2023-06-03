using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Queries.GetQuestionQueryList
{
    public class GetQuestionQueryList:IRequest<List<QuestionListVm>>
    {
    }
}
