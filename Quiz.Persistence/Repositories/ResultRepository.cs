using Quiz.Application.Contracts.Persistence;
using Quiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence.Repositories
{
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        public ResultRepository(QuizDbContext db) : base(db)
        {
            
        }

        public async Task<float>  TotalScoreResultAsync(int resultID)
        {
            
            float TotalScore=await _db.Answers.Where(x=>x.ResultID == resultID).SumAsync(x=>x.Score);
            return TotalScore;
        }
    }
}
