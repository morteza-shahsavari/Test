using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Queries.GetQuizPageList
{
    public class GetQuizQueryListPaging:IRequest<QuizPageListVm>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
