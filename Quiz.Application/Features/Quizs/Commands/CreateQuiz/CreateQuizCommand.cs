using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Commands.CreateQuiz
{
    public class CreateQuizCommand:IRequest<CreateQuizCommandResponse>
    {
        public string QuizName { get; set; }
        public DateTime BeginQuiz { get; set; }
        public DateTime EndQuiz { get; set; }
        public string QuizUrl { get; set; }
        public int Creator { get; set; }
        public string Description { get; set; }
    }
}
