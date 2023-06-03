using MediatR;
using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Quizs.Commands.DeleteQuiz
{
    public class DeleteQuizCommand:IRequest<BaseResponse>
    {
        public int QuizID { get; set; }
    }
}
