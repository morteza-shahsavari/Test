using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using Quiz.Domain.Entities;

namespace Quiz.Application.Features.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQueryHandler : IRequestHandler<GetQuestionDetailQuery, List<QuestionListVm>>
    {
        private readonly IAsyncRepository<Question> repo;
        private readonly IMapper mapper;
        public GetQuestionDetailQueryHandler(IAsyncRepository<Question> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<List<QuestionListVm>> Handle(GetQuestionDetailQuery request, CancellationToken cancellationToken)
        {
            var question=await repo.GetByIDAsync(request.Id);
            //if(question == null)
            //{
            //    throw new NotFoundException(nameof(Question), request.Id);
            //}
            return mapper.Map<List< QuestionListVm>>(question);
        }
    }
}
