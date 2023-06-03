using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using Quiz.Domain.Entities;
namespace Quiz.Application.Features.Questions.Queries.GetQuestionQueryListPaging
{
    public class GetQuestionQueryListPagingHandler : IRequestHandler<GetQuestionQueryListPaging, QuestionPageListVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Question> repo;
        public GetQuestionQueryListPagingHandler(IAsyncRepository<Question> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<QuestionPageListVm> Handle(GetQuestionQueryListPaging request, CancellationToken cancellationToken)
        {
            var pageQuestion = new QuestionPageListVm();
            var allQuestion = (await repo.GetPagedRespanseAsync(request.PageIndex, request.PageSize)).OrderBy(x => x.QuestionID);
            pageQuestion.RecordCount = allQuestion.Count();
            pageQuestion.PageSize = request.PageSize;
            pageQuestion.PageIndex = request.PageIndex;


            pageQuestion.QuestionListVm = mapper.Map<List<QuestionListVm>>(allQuestion);
            return pageQuestion;
        }
    }
}
