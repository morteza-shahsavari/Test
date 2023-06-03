using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Features.Results.Queries.GetResultQueryList;
using Quiz.Domain.Entities;

namespace Quiz.Application.Features.Results.Queries.GetResultQueryPageList
{
    public class GetResultQueryPageListHandler : IRequestHandler<GetResultQueryPageList, ResultPageListVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Result> repo;
        public GetResultQueryPageListHandler(IAsyncRepository<Result> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<ResultPageListVm> Handle(GetResultQueryPageList request, CancellationToken cancellationToken)
        {
            var pageResult = new ResultPageListVm();
            var allQuiz = (await repo.GetPagedRespanseAsync(request.PageIndex, request.PageSize)).OrderBy(x => x.ResultID);
            pageResult.RecordCount = allQuiz.Count();
            pageResult.PageSize = request.PageSize;
            pageResult.PageIndex = request.PageIndex;
            pageResult.ResultListVm = mapper.Map<List<ResultListVm>>(allQuiz);
            return pageResult;
        }
    }
}
