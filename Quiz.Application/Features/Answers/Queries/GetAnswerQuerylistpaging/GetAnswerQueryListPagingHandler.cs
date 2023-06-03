using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Queries.GetAnswerQuerylistpaging
{
    public class GetAnswerQueryListPagingHandler : IRequestHandler<GetAnswerQueryListPaging, PageAnswerListVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Answer> repo;
        public GetAnswerQueryListPagingHandler(IAsyncRepository<Answer> repo, IMapper mapper)
        {
            this.repo= repo;
            this.mapper= mapper;
        }
        public async Task<PageAnswerListVm> Handle(GetAnswerQueryListPaging request, CancellationToken cancellationToken)
        {
            var pageAnswer = new PageAnswerListVm();
            var allAnswer = (await repo.GetPagedRespanseAsync(request.PageIndex,request.PageSize)).OrderBy(x => x.AnswerID);
            pageAnswer.RecordCount= allAnswer.Count();
            pageAnswer.PageSize = request.PageSize;
            pageAnswer.PageIndex=request.PageIndex;
            

            pageAnswer.AnswerListVm = mapper.Map<List<AnswerListVm>>(allAnswer) ;
            return pageAnswer;

        }
    }
}
