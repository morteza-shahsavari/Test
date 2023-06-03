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
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(x=>x.ResultID);
            builder.Property(x => x.TotalScore).IsRequired();
           builder.HasMany(x=>x.Answers).WithOne(x=>x.Result).HasForeignKey(x=>x.ResultID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
