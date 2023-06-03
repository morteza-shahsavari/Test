using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Queries.GetQuestionQueryList
{
    public class GetQuestionQureyListHandler : IRequestHandler<GetQuestionQueryList, List<QuestionListVm>>
    {
        private readonly IAsyncRepository<Question> repo;
        private readonly IMapper mapper;
        public GetQuestionQureyListHandler(IAsyncRepository<Question> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<List<QuestionListVm>> Handle(GetQuestionQueryList request, CancellationToken cancellationToken)
        {
            var allQuestion = (await repo.GetAllAsync()).OrderBy(x => x.QuestionID);
           return mapper.Map<List<QuestionListVm>>(allQuestion);
        }
    }
}
