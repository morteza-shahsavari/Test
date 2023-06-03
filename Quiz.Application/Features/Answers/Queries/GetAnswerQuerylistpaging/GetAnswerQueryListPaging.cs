﻿using MediatR;
using Quiz.Application.Features.Answers.Queries.GetAnswerQueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Features.Answers.Queries.GetAnswerQuerylistpaging
{
    public class GetAnswerQueryListPaging:IRequest<PageAnswerListVm>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
