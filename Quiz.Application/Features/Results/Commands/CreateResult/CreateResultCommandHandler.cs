using AutoMapper;
using MediatR;
using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;

namespace Quiz.Application.Features.Results.Commands.CreateResult
{
    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, CreateResultCommandResponse>
    {
        private readonly IAsyncRepository<Result> repo;
        private readonly IMapper mapper;
        public CreateResultCommandHandler(IAsyncRepository<Result> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<CreateResultCommandResponse> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            var createResultcommandResponse= new CreateResultCommandResponse();
            var validator = new CreateResultCommandValidator();
            var validatResult=await validator.ValidateAsync(request);
            if (validatResult.Errors.Count > 0)
            {
                createResultcommandResponse.Success = false;
                createResultcommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validatResult.Errors)
                {
                    createResultcommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(createResultcommandResponse.Success)
            {
                var result = mapper.Map<Result>( request);
                result.TotalScore= 0;
                result=await repo.AddAsync(result);
                createResultcommandResponse.ResultID = result.ResultID;
            }
            return createResultcommandResponse;
        }
    }
}
