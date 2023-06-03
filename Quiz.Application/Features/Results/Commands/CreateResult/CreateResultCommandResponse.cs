using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Commands.CreateResult
{
    public class CreateResultCommandResponse:BaseResponse
    {
        public CreateResultCommandResponse() : base() { }
        public int ResultID { get; set; }
    }
}
