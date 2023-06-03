using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;

namespace Quiz.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionCommandResponse>
    {
        private readonly IAsyncRepository<Question> repo;
        private readonly IMapper mapper;
        public CreateQuestionCommandHandler(IAsyncRepository<Question> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var createQuestionCommandResponse=new CreateQuestionCommandResponse();
            var validetor = new CreateQuestionCommandValidator();
            var validatorResult=await validetor.ValidateAsync(request, cancellationToken);
            if(validatorResult.Errors.Count> 0)
            {
                createQuestionCommandResponse.Success = false;
                createQuestionCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validatorResult.Errors)
                {
                    createQuestionCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(createQuestionCommandResponse.Success)
            {
                var question = mapper.Map<Question>(request);
                question=await repo.AddAsync(question);
                createQuestionCommandResponse.QuestionID = question.QuestionID;
            }
            return createQuestionCommandResponse;
        }
    }
}
