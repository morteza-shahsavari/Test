using Quiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entities
{
    public class Question:AuditableEntity
    {
        public int QuestionID { get; set; }
        public int  QuizID { get; set; }
        public string question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
        public string Picture { get; set; }
        public float Score { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Question()
        {
            this.Answers = new List<Answer>();
        }


    }
}
