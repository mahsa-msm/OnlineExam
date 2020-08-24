using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using OnlineExam.Domain.Core.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Questions
{
    internal class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(c => c.Text).HasMaxLength(500).IsRequired();

        }

    }
}

