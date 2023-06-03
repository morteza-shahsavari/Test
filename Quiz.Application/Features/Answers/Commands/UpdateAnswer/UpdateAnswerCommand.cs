using MediatR;
using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommand:IRequest<BaseResponse>
    {
        public int AnswerID { get; set; }
        public string Respond { get; set; }
        public float Score { get; set; }
    }
}
