using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Features.Questions.Queries.GetQuestionQueryListPaging;
using Quiz.Application.Features.Quizs.Commands.CreateQuiz;
using Quiz.Application.Features.Quizs.Commands.DeleteQuiz;
using Quiz.Application.Features.Quizs.Commands.UpdateQuiz;
using Quiz.Application.Features.Quizs.Queries.GetQuizDetail;
using Quiz.Application.Features.Quizs.Queries.GetQuizPageList;
using Quiz.Application.Features.Quizs.Queries.GetQuizsList;
using Quiz.Application.Response;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMediator mediator;
        public QuizController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet ("all",Name = "GetAllQuizs") ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QuizListVm>>> GetAllQuizs()
        {
            var dtos = await mediator.Send(new GetQuizListQueryList());
            return Ok(dtos);
        }
        
        [HttpGet("{id}", Name = "GetQuizById")]
        public async Task<ActionResult<QuizListVm>>GetQuizByid(int id)
        {
            var QuizDetailQurey = new GetQuizDetailQuery() { Id = id };
            return Ok(await mediator.Send(QuizDetailQurey));      
        }

        [HttpGet("{PageIndex}-{PageSize}", Name = "GetQuizListPaging")]
        public async Task<ActionResult<QuestionPageListVm>> GetQuizListPaging(int PageIndex, int PageSize)
        {
            var Quizlist = new GetQuizQueryListPaging() { PageIndex = PageIndex, PageSize = PageSize };
            return Ok(await mediator.Send(Quizlist));
        }




        [HttpPost(Name = "AddNewQuiz")]
        public async Task<ActionResult<CreateQuizCommandResponse>> AddNewQuiz([FromBody] CreateQuizCommand createQuizCommand)
        {
            var response = await mediator.Send(createQuizCommand);
            return Ok(response);
        }
        [HttpDelete("{id}", Name = "DeleteQuiz")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var DeleteQuiz=new DeleteQuizCommand() { QuizID = id };
            return Ok( await mediator.Send(DeleteQuiz));
        }
        [HttpPut(Name ="UpdateQuiz")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> Update([FromBody]UpdateQuizCommand updateQuizCommand)
        {
            return Ok( await mediator.Send(updateQuizCommand));
        }
    }
}
