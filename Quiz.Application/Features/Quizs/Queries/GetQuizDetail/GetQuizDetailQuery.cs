

using MediatR;
using Quiz.Application.Features.Quizs.Queries.GetQuizsList;

namespace Quiz.Application.Features.Quizs.Queries.GetQuizDetail
{
    public class GetQuizDetailQuery:IRequest<QuizListVm>
    {
        public int Id { get; set; }
    }
}
