using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Queries.GetAnswerQueryList
{
    public class GetAnswerQueryListHandler : IRequestHandler<GetAnswerQueryList, List<AnswerListVm>>
    {
        private readonly IAsyncRepository<Answer> repo;
        private readonly IMapper mapper;
        public GetAnswerQueryListHandler(IAsyncRepository<Answer> repo, IMapper mapper)
        {
            this.mapper= mapper;
            this.repo= repo;
        }
        public async Task <List<AnswerListVm>> Handle(GetAnswerQueryList request, CancellationToken cancellationToken)
        {
            var allAnswer = (await repo.GetAllAsync()).OrderBy(x => x.AnswerID);
            return mapper.Map<List< AnswerListVm>>(allAnswer);
        }
    }
}
