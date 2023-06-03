using MediatR;
using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestioncommand:IRequest<BaseResponse>
    {
        public int QuestionID { get; set; }
    }
}
