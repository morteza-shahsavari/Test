

namespace Quiz.Application.Features.Quizs.Queries.GetQuizsList
{
    public class QuizListVm
    {
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public DateTime BeginQuiz { get; set; }
        public DateTime EndQuiz { get; set; }
        public string QuizUrl { get; set; }
    }
}
