using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Domain.Entities.Quiz>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Quiz> builder)
        {
            builder.HasKey(x => x.QuizID);
            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.QuizName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.QuizUrl).IsRequired().HasMaxLength(400);
            builder.HasMany(x=>x.Questions).WithOne(x=>x.Quiz).HasForeignKey(x=>x.QuizID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Results).WithOne(x=>x.Quiz).HasForeignKey(x=>x.QuizID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
