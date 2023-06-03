using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommand:IRequest<CreateAnswerCommandResponse>
    {
        public string Respond { get; set; }
        public float Score { get; set; }
        public int QuestionID { get; set; }
        public int ResultID { get; set; }
    }
}
