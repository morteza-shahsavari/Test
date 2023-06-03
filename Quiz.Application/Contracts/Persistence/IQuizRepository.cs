
namespace Quiz.Application.Contracts.Persistence
{
    public interface IQuizRepository:IAsyncRepository<Quiz.Domain.Entities.Quiz>
    {
    }
}
