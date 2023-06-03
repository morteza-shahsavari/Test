using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Response;

namespace Quiz.Application.Features.Quizs.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Quiz.Domain.Entities.Quiz> repo;
        private readonly IMapper mapper;
        public UpdateQuizCommandHandler(IAsyncRepository<Quiz.Domain.Entities.Quiz> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;

        }
        public async Task<BaseResponse> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var updateToQuiz = await repo.GetByIDAsync(request.QuizID);
            if (updateToQuiz == null)
            {
                throw new NotFoundException(nameof(Quiz.Domain.Entities.Quiz), request.QuizID);
            }
            var Validtor = new UpdateQuizCommandValidator();
            var ValidtorResult = await Validtor.ValidateAsync(request);
            if (ValidtorResult.Errors.Count>0 )
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in ValidtorResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
                throw new ValidationException(ValidtorResult);
            }
            if (response.Success)
            {
                var quiz = mapper.Map<Quiz.Domain.Entities.Quiz>(request);
                await repo.UpdateAsync(quiz);
                response.Message = "Update Quiz SuccessFuly";

            }

            return response;

        }
    }
}
