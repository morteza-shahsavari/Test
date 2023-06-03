using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Queries.GetResultQueryList
{
    public class ResultListVm
    {
        public int ResultID { get; set; }
        public int   UserID  { get; set; }
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public float TotalScore { get; set; }
    }
}
