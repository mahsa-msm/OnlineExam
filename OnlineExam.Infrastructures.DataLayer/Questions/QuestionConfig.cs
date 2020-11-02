using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.Questions;

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

