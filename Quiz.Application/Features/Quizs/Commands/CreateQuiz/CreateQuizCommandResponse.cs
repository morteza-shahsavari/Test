using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Commands.CreateQuiz
{
    public class CreateQuizCommandResponse:BaseResponse
    {
        public CreateQuizCommandResponse() : base() { }

        public int QuizID { get; set; }
    }
}
