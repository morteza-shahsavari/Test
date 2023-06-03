using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using Quiz.Domain.Entities;
using Quiz.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Queries.GetAnswerDetail
{
    public class GetAnswerDetailQueryHandler : IRequestHandler<GetAnswerDetailQuery, AnswerListVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Answer> Repo;
        public GetAnswerDetailQueryHandler(IAsyncRepository<Answer> Repo, IMapper mapper)
        {
            this.mapper= mapper;
            this.Repo = Repo;
        }
        public async Task<AnswerListVm> Handle(GetAnswerDetailQuery request, CancellationToken cancellationToken)
        {
            var answer=await Repo.GetByIDAsync(request.Id);
            if(answer == null)
            {
                throw new NotFoundException(nameof(Answer),request.Id);
            }
            return mapper.Map<AnswerListVm>(answer);
        }
    }
}
