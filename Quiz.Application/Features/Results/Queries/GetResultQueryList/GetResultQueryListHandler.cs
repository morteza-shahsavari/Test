using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Queries.GetResultQueryList
{
    public class GetResultQueryListHandler : IRequestHandler<GetResultQueryList, List<ResultListVm>>
    {
        private readonly IAsyncRepository<Result> repo;
        private readonly IMapper mapper;
        public GetResultQueryListHandler(IAsyncRepository<Result> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;   
        }
      
        public async Task<List<ResultListVm>> Handle(GetResultQueryList request, CancellationToken cancellationToken)
        {
            var allResult =await repo.GetAllAsync();
            return mapper.Map<List<ResultListVm>> (allResult);
        }
    }
}
