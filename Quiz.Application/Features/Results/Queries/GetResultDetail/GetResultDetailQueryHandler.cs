using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Features.Results.Queries.GetResultQueryList;
using Quiz.Domain.Entities;

namespace Quiz.Application.Features.Results.Queries.GetResultDetail
{
    public class GetResultDetailQueryHandler : IRequestHandler<GetResultDetailQuery, ResultListVm>
    {
        private readonly IAsyncRepository<Result> repo;
        private readonly IMapper mapper;
        public GetResultDetailQueryHandler(IAsyncRepository<Result> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<ResultListVm> Handle(GetResultDetailQuery request, CancellationToken cancellationToken)
        {
           var result=await repo.GetByIDAsync(request.Id);
            //if (result == null) 
            //{
            //    throw new NotFoundException(nameof(Result), request.Id);
            //}
            var resultvm= mapper.Map<ResultListVm>(result);
            return resultvm;
        }
    }
}
