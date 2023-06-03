using MediatR;
using Quiz.Application.Response;

namespace Quiz.Application.Features.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommand:IRequest<BaseResponse>
    {
        public int QuestionID { get; set; }
        public int QuizID { get; set; }
        public string question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
        public string Picture { get; set; }
        public float Score { get; set; }
    }
}
