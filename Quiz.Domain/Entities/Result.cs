using Quiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entities
{
    public class Result:AuditableEntity
    {
        public int ResultID { get; set; }
        public int  UserID { get; set; }
        public int  QuizID { get; set; }
        public float TotalScore { get; set;}
        public  Quiz Quiz { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Result()
        {
            this.Answers = new List<Answer>();
        }
    }
}
