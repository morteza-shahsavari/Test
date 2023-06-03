using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.QuestionID);
            //builder.Property(x=>x.Score).IsRequired(false);
            builder.Property(x=>x.Answer).IsRequired(false);
            builder.Property(x=>x.Option1).IsRequired(false);
            builder.Property(x => x.Option2).IsRequired(false);
            builder.Property(x => x.Option3).IsRequired(false);
            builder.Property(x => x.Option4).IsRequired(false);
            builder.Property(x=>x.Picture).IsRequired(false);
            builder.HasMany(x=>x.Answers).WithOne(x=> x.question)
                .HasForeignKey(x=>x.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
