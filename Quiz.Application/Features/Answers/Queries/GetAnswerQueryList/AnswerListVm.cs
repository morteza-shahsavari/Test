using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Queries.GetAnswerQueryList
{
    public class AnswerListVm
    {
        public int AnswerID { get; set; }
        public string Respond { get; set; }
        public float Score { get; set; }
        public int QuestionID { get; set; }
        public string Soal { get; set; }
        public string QuizName { get; set; }
    }
}
