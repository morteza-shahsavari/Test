using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Features.Answers.Queries.GetAnswerQuerylistpaging;
using Quiz.Application.Features.Questions.Commands.CreateQuestion;
using Quiz.Application.Features.Questions.Commands.DeleteQuestion;
using Quiz.Application.Features.Questions.Commands.UpdateQuestion;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryList;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryListPaging;
using Quiz.Application.Features.Quizs.Commands.DeleteQuiz;
using Quiz.Application.Features.Quizs.Queries.GetQuizDetail;
using Quiz.Application.Response;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator mediator;
        public QuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("all",Name ="GetallQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<QuestionListVm>> GetAllQusetion()
        {
            var dtos = await mediator.Send(new GetQuestionQueryList());
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetQuestionById")]
        public async Task<ActionResult<QuestionListVm>> GetQuestionById(int id)
        {
            var question = new GetQuizDetailQuery() { Id = id };
            return Ok(await mediator.Send(question));
        }

        [HttpGet("{PageIndex}-{PageSize}", Name = "GetQuestionListPaging")]
        public async Task<ActionResult<QuestionPageListVm>> GetQuestionListPaging(int PageIndex, int PageSize)
        {
            var Questionlist = new GetQuestionQueryListPaging() { PageIndex = PageIndex, PageSize = PageSize };
            return Ok(await mediator.Send(Questionlist));
        }


        [HttpPost(Name ="AddnewQuestion")]
         public async Task<ActionResult<CreateQuestionCommandResponse>> AddNewQuestion([FromBody] CreateQuestionCommand createQuestionCommand)
        {
            var response= await mediator.Send(createQuestionCommand);
            return Ok(response);
        }
        [HttpPut(Name ="UpdateQuestion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> UpdateQuestion([FromBody]UpdateQuestionCommand updateQuestionCommand)
        {
            return Ok(await mediator.Send(updateQuestionCommand));
        }

        [HttpDelete("{id}", Name = "DeleteQuestion")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> DeleteQuestion(int id)
        {
            var question = new DeleteQuestioncommand { QuestionID = id };
            return Ok(await mediator.Send(question));
        }
    }
}
