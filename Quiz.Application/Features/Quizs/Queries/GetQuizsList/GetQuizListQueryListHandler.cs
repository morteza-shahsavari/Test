using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Queries.GetQuizsList
{
    public class GetQuizListQueryListHandler : IRequestHandler<GetQuizListQueryList, List<QuizListVm>>
    {
        private readonly IAsyncRepository<Quiz.Domain.Entities.Quiz> repo;
        private readonly IMapper mapper;
        public GetQuizListQueryListHandler(IAsyncRepository<Quiz.Domain.Entities.Quiz> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<List<QuizListVm>> Handle(GetQuizListQueryList request, CancellationToken cancellationToken)
        {
            var allQuizs = (await repo.GetAllAsync()).OrderBy(x => x.QuizName);
            return mapper.Map<List<QuizListVm>>(allQuizs);
        }
    }
}
