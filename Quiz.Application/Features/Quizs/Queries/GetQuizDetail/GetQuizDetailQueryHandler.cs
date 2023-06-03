using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Features.Quizs.Queries.GetQuizsList;


namespace Quiz.Application.Features.Quizs.Queries.GetQuizDetail
{
    public class GetQuizDetailQueryHandler : IRequestHandler<GetQuizDetailQuery, QuizListVm>
    {
        private readonly IAsyncRepository<Quiz.Domain.Entities.Quiz> repo;
        private readonly IMapper mapper;
        public GetQuizDetailQueryHandler(IAsyncRepository<Quiz.Domain.Entities.Quiz> repo,IMapper mapper)
        {
            this.mapper= mapper;
            this.repo= repo;
        }
        public async Task<QuizListVm> Handle(GetQuizDetailQuery request, CancellationToken cancellationToken)
        {
            var quiz = await repo.GetByIDAsync(request.Id);
            ////if (quiz == null)
            ////{
            ////    throw new NotFoundException(nameof(Quiz.Domain.Entities.Quiz), request.Id);
            ////}
            var quizlistVm = mapper.Map<QuizListVm>(quiz);
           
           
            return quizlistVm;
        }
    }
}
