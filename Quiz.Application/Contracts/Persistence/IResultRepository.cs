using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Contracts.Persistence
{
    public interface IResultRepository:IAsyncRepository<Result>
    {
        Task<float> TotalScoreResultAsync(int resultID);
    }
}
