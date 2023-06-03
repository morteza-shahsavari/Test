using MediatR;
using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Commands.UpdateQuiz
{
    public class UpdateQuizCommand:IRequest<BaseResponse>
    {
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public DateTime BeginQuiz { get; set; }
        public DateTime EndQuiz { get; set; }
        public string QuizUrl { get; set; }
        public string Description { get; set; }
    }
}
