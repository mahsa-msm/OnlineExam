using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Core.ExamQuestions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.ExamQuestions
{

    internal class ExamQuestionsConfig : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> modelBuilder)
        {

            modelBuilder.HasKey(x=>x.Id);

            modelBuilder.HasOne(b => b.Exam)
                .WithMany(b => b.ExamQuestions)
                .HasForeignKey(b => b.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.HasOne(b => b.Question)
                .WithMany(c => c.ExamQuestions)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

}

