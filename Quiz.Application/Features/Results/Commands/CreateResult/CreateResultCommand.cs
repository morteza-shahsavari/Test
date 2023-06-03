using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Commands.CreateResult
{
    public class CreateResultCommand:IRequest<CreateResultCommandResponse>
    {
        public int UserID { get; set; }
        public int QuizID { get; set; }
        public float TotalScore { get; set; }
    }
}
