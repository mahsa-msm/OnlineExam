using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Answers
{
    internal class AnswerConfig : IEntityTypeConfiguration<Answer>
    {


        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasOne(b => b.AppUser)
                .WithMany(c => c.Answers)
                .HasForeignKey(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
