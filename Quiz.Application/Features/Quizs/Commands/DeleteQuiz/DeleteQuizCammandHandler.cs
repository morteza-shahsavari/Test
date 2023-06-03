using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Commands.DeleteQuiz
{
    public class DeleteQuizCammandHandler : IRequestHandler<DeleteQuizCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Quiz.Domain.Entities.Quiz> repo;
        public DeleteQuizCammandHandler(IAsyncRepository<Quiz.Domain.Entities.Quiz> repo)
        {
            this.repo = repo;
        }
        public async Task<BaseResponse> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var quizToDelete = await repo.GetByIDAsync(request.QuizID);
            if(quizToDelete == null)
            {
                throw new NotFoundException(nameof(Quiz.Domain.Entities.Quiz),request.QuizID);
            }
            await repo.DeleteAsync(quizToDelete);
            response.Message = "Remove Quiz SuccessFuly";
            return response;
        }
    }
}
