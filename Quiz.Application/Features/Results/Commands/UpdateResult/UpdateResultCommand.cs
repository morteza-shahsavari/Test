using MediatR;
using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Commands.UpdateResult
{
    public class UpdateResultCommand:IRequest<BaseResponse>
    {
        public int ResultID { get; set; }
        public int UserID { get; set; }
        public int QuizID { get; set; }
        public float TotalScore { get; set; }
    }
}
