using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Contracts.Persistence;
using Quiz.Persistence.Repositories;


namespace Quiz.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<QuizDbContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(configuration["ConnectionString"]);
                
            },ServiceLifetime.Scoped);
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            return services;
        }
    }
}
