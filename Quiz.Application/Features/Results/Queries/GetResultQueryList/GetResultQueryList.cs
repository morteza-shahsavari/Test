using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Results.Queries.GetResultQueryList
{
    public class GetResultQueryList:IRequest<List<ResultListVm>>
    {
    }
}
