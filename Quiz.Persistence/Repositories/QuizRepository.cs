using Quiz.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence.Repositories
{
    public class QuizRepository : BaseRepository<Quiz.Domain.Entities.Quiz>, IQuizRepository
    {
        public QuizRepository(QuizDbContext db) : base(db)
        {
        }
    }
}
