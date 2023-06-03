using Quiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entities
{
    public class Answer:AuditableEntity
    {
        public int AnswerID { get; set; }
        public string Respond { get; set; }
        public float Score { get; set; }
        public int QuestionID { get; set; }
        public int ResultID { get; set; }
        public Question question { get; set; }
        public Result Result { get; set; }
    }
}
