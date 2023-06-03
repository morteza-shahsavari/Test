using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Features.Answers.Queries.GetAnswerDetail;
using Quiz.Application.Features.Answers.Queries.GetAnswerQuerylistpaging;
using Quiz.Application.Features.Results.Commands.CreateResult;
using Quiz.Application.Features.Results.Commands.UpdateResult;
using Quiz.Application.Features.Results.Queries.GetResultQueryList;
using Quiz.Application.Features.Results.Queries.GetResultQueryPageList;
using Quiz.Application.Response;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IMediator mediator;
        public ResultController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("all",Name ="GetAllResult")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ResultListVm>>> GetAllResult()
        {
            var dots= await mediator.Send(new GetResultQueryList());
            return Ok(dots);
        }



        [HttpGet("{id}",Name ="GetResultById")]
        public async Task<ActionResult< ResultListVm>>GetResult(int id)
        {
            var result=new GetAnswerDetailQuery() { Id = id };
            return Ok(await mediator.Send(result));
        }

        [HttpGet("{PageIndex}-{PageSize}", Name = "GetResultListPaging")]
        public async Task<ActionResult<ResultPageListVm>> GetResultListPaging(int PageIndex, int PageSize)
        {
            var Resultlist = new GetResultQueryPageList() { PageIndex = PageIndex, PageSize = PageSize };
            return Ok(await mediator.Send(Resultlist));
        }

        [HttpPost(Name ="AddNewResult")]
        public async Task<ActionResult<CreateResultCommandResponse>> AddNewResult([FromForm]CreateResultCommand createResultCommand)
        {
            var response = await mediator.Send(createResultCommand);
            return Ok(response);
        }

        [HttpPut(Name ="UpdateResult")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> UpdateResult([FromBody]UpdateResultCommand updateResultCommand)
        {
            return Ok( await mediator.Send(updateResultCommand));
        }
    }

}
