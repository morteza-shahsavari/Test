using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreateAnswerCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Answer> repo;
        private readonly IAnswerRepository answerRepository;
        private readonly IQuestionRepository questionRepository;
        public CreateAnswerCommandHandler(IAsyncRepository<Answer> repo, IMapper mapper, IAnswerRepository answerRepository, IQuestionRepository questionRepository)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.answerRepository = answerRepository;
            this.questionRepository = questionRepository;
        }
        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var createAnswerCommandResponse=new CreateAnswerCommandResponse();
            var validator = new CreateAnswerCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if(validatorResult.Errors.Count>0)
            {
                createAnswerCommandResponse.Success = false;
                createAnswerCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validatorResult.Errors)
                {
                    createAnswerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(createAnswerCommandResponse.Success)
            {
                var answer = mapper.Map<Answer>(request);
                var question = await questionRepository.GetByIDAsync(answer.QuestionID);
                answer.Score = question.Answer== answer.Respond ? question.Score : 0;
                
                answer=await repo.AddAsync(answer);
                createAnswerCommandResponse.AnswerID= answer.AnswerID;
            }
            return createAnswerCommandResponse;
        }
    }
}
