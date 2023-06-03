using Quiz.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandResponse:BaseResponse
    {
        public CreateAnswerCommandResponse() : base() 
        {
            
        }
        public int AnswerID { get; set; }
    }
}
