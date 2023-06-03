using Quiz.Application.Response;


namespace Quiz.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandResponse:BaseResponse
    {
        public CreateQuestionCommandResponse() : base() 
        {
            
        }
        public int QuestionID { get; set; }
    }
}
