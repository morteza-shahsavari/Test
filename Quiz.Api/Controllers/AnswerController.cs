using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Features.Answers.Commands.CreateAnswer;
using Quiz.Application.Features.Answers.Commands.UpdateAnswer;
using Quiz.Application.Features.Answers.Queries.GetAnswerDetail;
using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using Quiz.Application.Features.Answers.Queries.GetAnswerQuerylistpaging;
using Quiz.Application.Response;
using Quiz.Domain.Entities;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator mediator;
        public AnswerController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("all", Name = "GetAllAnswer")]
        public async Task<ActionResult<List<AnswerListVm>>> GetAllAnswer()
        {
            var dtos = await mediator.Send(new GetAnswerQueryList());
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetAnswerById")]
        public async Task<ActionResult<AnswerListVm>> GetAnswerById(int id)
        {
            var AnwserDetial = new GetAnswerDetailQuery() { Id = id };
            return Ok(await mediator.Send(AnwserDetial));
        }

        [HttpGet("{PageIndex}-{PageSize}", Name = "GetAnswerListPaging")]
        public async Task<ActionResult<PageAnswerListVm>> GetAnswerListPaging(int PageIndex,int PageSize)
        {
            var Anwserlist = new GetAnswerQueryListPaging() { PageIndex =PageIndex,PageSize=PageSize };
            return Ok(await mediator.Send(Anwserlist));
        }


        [HttpPost(Name = "AddNewAnswer")]
        public async Task<ActionResult<CreateAnswerCommandResponse>> AddNewAnswer([FromBody] CreateAnswerCommand createAnswerCommand)
        {
            return Ok(await mediator.Send(createAnswerCommand));
        }

        [HttpPut(Name = "UpdateAnswer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> UpdateAnswer([FromBody]UpdateAnswerCommand updateAnswerCommand)
        {
            return Ok(await mediator.Send( updateAnswerCommand));
        }
    }
}
