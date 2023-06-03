using Quiz.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entities
{
    public class Quiz:AuditableEntity
    {
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public DateTime BeginQuiz { get; set; }
        public DateTime EndQuiz { get; set;}
        public string QuizUrl { get; set;}
        public int Creator { get; set;}
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Result> Results { get; set; }
        public Quiz()
        {
            this.Questions = new List<Question>();
            this.Results = new List<Result>();
        }
    }
}
