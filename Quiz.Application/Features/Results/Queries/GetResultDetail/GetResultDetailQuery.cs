using MediatR;
using Quiz.Application.Features.Results.Queries.GetResultQueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Queries.GetResultDetail
{
    public class GetResultDetailQuery:IRequest<ResultListVm>
    {
        public int Id { get; set; }
    }
}
