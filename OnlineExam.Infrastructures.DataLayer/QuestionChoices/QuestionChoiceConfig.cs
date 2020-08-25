using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.QuestionChoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.QuestionChoices
{
    internal class QuestionChoiceConfig : IEntityTypeConfiguration<QuestionChoice>
    {
        public void Configure(EntityTypeBuilder<QuestionChoice> builder)
        {
            builder.HasKey(x=> x.Id );

            builder.HasOne(b => b.Question)
                .WithMany(b => b.QuestionChoices)
                .HasForeignKey(b => b.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Choice)
                .WithMany(b => b.QuestionChoice)
                .HasForeignKey(b => b.ChoiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
