using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Queries.GetResultQueryPageList
{
    public class GetResultQueryPageList:IRequest<ResultPageListVm>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
