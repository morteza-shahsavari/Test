using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Queries.GetQuizsList
{
    public class GetQuizListQueryList:IRequest<List<QuizListVm>>
    {
    }
}
