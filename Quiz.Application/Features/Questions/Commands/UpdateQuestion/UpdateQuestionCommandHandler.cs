using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Response;
using Quiz.Domain.Entities;

namespace Quiz.Application.Features.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Question> repo;
        private readonly IMapper mapper;
        public UpdateQuestionCommandHandler(IAsyncRepository<Question> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public async Task<BaseResponse> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var updateQuestionCommandResponse=new BaseResponse();
            var updateToQuestion = await repo.GetByIDAsync(request.QuestionID);
            if (updateToQuestion == null)
            {
                throw new NotFoundException(nameof(Question), request.QuestionID);
            }
            var validator = new UpdateQuestionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if(validatorResult.Errors.Count>0)
            {
                updateQuestionCommandResponse.Success = false;
                updateQuestionCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors)
                {
                    updateQuestionCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                throw new ValidationException(validatorResult);
            }
            if (updateQuestionCommandResponse.Success)
            {
                var question = mapper.Map<Question>(request);
                await repo.UpdateAsync(question);
                updateQuestionCommandResponse.Message = "Update Question SuccessFuly";
            }
            return updateQuestionCommandResponse;
        }
    }
}
