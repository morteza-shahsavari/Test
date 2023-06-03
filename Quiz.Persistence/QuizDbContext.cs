using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common;
using Quiz.Domain.Entities;
using Quiz.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence
{
    public class QuizDbContext:DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options):base(options)
        {
            
        }
        public DbSet<Domain.Entities.Quiz> Quizs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration<Quiz.Domain.Entities.Quiz>(new Quiz.Persistence.Configurations.QuizConfiguration());
            modelBuilder.ApplyConfiguration<Question>(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration<Result>(new ResultConfiguration());
            modelBuilder.ApplyConfiguration<Answer>(new AnswerConfiguration());
           // modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizDbContext).Assembly); یا این جا همه
            base.OnModelCreating(modelBuilder);
        }
        
            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>()) 
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate= DateTime.Now;
                        break;
                        case EntityState.Modified:
                        entry.Entity.LastModifiedDate= DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
