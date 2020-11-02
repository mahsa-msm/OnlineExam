using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.Exams;

namespace OnlineExam.Infrastructures.DataLayer.Exams
{

    internal class ExamConfig : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();

            builder.HasOne(b => b.Course)
                 .WithMany(c => c.Exams)
                 .HasForeignKey(c => c.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
