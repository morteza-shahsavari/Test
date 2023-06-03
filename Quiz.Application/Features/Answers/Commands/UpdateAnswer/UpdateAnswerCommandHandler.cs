using AutoMapper;
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

namespace Quiz.Application.Features.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Answer> repo;
        private readonly IMapper mapper;
        private readonly IAnswerRepository answerRepository;
        private readonly IQuestionRepository questionRepository;
        public UpdateAnswerCommandHandler(IAsyncRepository<Answer> repo, IMapper mapper, IAnswerRepository answerRepository, IQuestionRepository questionRepository)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.answerRepository = answerRepository;
            this.questionRepository = questionRepository;
        }
        public async Task<BaseResponse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var updateAnswerResponse = new BaseResponse();
            var updateToAnswer = await repo.GetByIDAsync(request.AnswerID);
            if (updateToAnswer == null)
            {

                throw new NotFoundException(nameof(Answer),request.AnswerID);
            }
            var answer=mapper.Map<Answer>(request);
            var question = await questionRepository.GetByIDAsync(answer.QuestionID);
            answer.Score = question.Answer== answer.Respond ? question.Score : 0;
            await repo.UpdateAsync(answer);
            updateAnswerResponse.Message = "Update Answer SuccessFuly";
            return updateAnswerResponse;

        }
    }
}
