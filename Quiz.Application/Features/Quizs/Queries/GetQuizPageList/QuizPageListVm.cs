using Quiz.Application.Features.Quizs.Queries.GetQuizsList;


namespace Quiz.Application.Features.Quizs.Queries.GetQuizPageList
{
    public class QuizPageListVm
    {
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public ICollection<QuizListVm>? QuizListVm { get; set; }
    }
}
