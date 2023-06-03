using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Application.Exceptions;
using Quiz.Application.Response;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestioncommand, BaseResponse>
    {
        private readonly IAsyncRepository<Question> repo;
        public DeleteQuestionCommandHandler(IAsyncRepository<Question> repo)
        {
            this.repo=repo;
        }
        public async Task<BaseResponse> Handle(DeleteQuestioncommand request, CancellationToken cancellationToken)
        {
            var response=new BaseResponse();
            var DeleteToQuestion = await repo.GetByIDAsync(request.QuestionID);
            if (DeleteToQuestion == null)
            {
                throw new NotFoundException(nameof(Question),request.QuestionID);
            }
            await repo.DeleteAsync(DeleteToQuestion);
            response.Message = "Remove Question SuccessFuly";
            return response;
        }
    }
}
