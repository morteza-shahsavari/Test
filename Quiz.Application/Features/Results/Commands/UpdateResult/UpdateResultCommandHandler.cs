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

namespace Quiz.Application.Features.Results.Commands.UpdateResult
{
    public class UpdateResultCommandHandler : IRequestHandler<UpdateResultCommand, BaseResponse>
    {
        private readonly IAsyncRepository<Result> repo;
        private readonly IMapper mapper;
        private readonly IResultRepository resultRepository;
        public UpdateResultCommandHandler(IAsyncRepository<Result> repo, IMapper mapper, IResultRepository resultRepository)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.resultRepository = resultRepository;
        }
        public async Task<BaseResponse> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
        {
            var updateResultCommandResponse = new BaseResponse();
            var result = await repo.GetByIDAsync(request.ResultID);
            if (result==null)
            {
                throw new NotFoundException(nameof(result),request.ResultID);
            }
            var validator = new UpdateResultCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if(validatorResult.Errors.Count>0)
            {
                updateResultCommandResponse.Success = false;
                updateResultCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validatorResult.Errors)
                {
                    updateResultCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                throw new ValidationException(validatorResult);
            }
            if (updateResultCommandResponse.Success)
            {
                var Result = mapper.Map<Result>(request);
                Result.TotalScore = await resultRepository.TotalScoreResultAsync(Result.ResultID);
                await repo.UpdateAsync(Result);
                updateResultCommandResponse.Message = "Update Result SuccessFuly";
            }
            return updateResultCommandResponse;
        }
    }
}
