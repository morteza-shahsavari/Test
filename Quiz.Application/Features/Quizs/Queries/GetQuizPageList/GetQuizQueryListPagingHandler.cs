using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Features.Quizs.Queries.GetQuizsList;


namespace Quiz.Application.Features.Quizs.Queries.GetQuizPageList
{
    public class GetQuizQueryListPagingHandler : IRequestHandler<GetQuizQueryListPaging, QuizPageListVm>
    {

        private readonly IMapper mapper;
        private readonly IAsyncRepository<Quiz.Domain.Entities.Quiz> repo;
        public GetQuizQueryListPagingHandler(IAsyncRepository<Quiz.Domain.Entities.Quiz> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<QuizPageListVm> Handle(GetQuizQueryListPaging request, CancellationToken cancellationToken)
        {
            var pageQuiz = new QuizPageListVm();
            var allQuiz = (await repo.GetPagedRespanseAsync(request.PageIndex, request.PageSize)).OrderBy(x => x.QuizID);
            pageQuiz.RecordCount = allQuiz.Count();
            pageQuiz.PageSize = request.PageSize;
            pageQuiz.PageIndex = request.PageIndex;
            pageQuiz.QuizListVm = mapper.Map<List<QuizListVm>>(allQuiz);
            return pageQuiz;
        }
    }
}
