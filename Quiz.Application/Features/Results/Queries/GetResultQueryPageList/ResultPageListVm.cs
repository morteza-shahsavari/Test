using Quiz.Application.Features.Results.Queries.GetResultQueryList;
namespace Quiz.Application.Features.Results.Queries.GetResultQueryPageList
{
    public class ResultPageListVm
    {
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public ICollection<ResultListVm>? ResultListVm { get; set; }
    }
}
