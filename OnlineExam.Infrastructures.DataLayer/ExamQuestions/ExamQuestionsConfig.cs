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

            modelBuilder.HasKey(b => new { b.ExamId, b.QuestionId });
            modelBuilder.HasOne(bc => bc.Exam)
                .WithMany(b => b.ExamQuestions)
                .HasForeignKey(bc => bc.ExamId);
            modelBuilder.HasOne(bc => bc.Question)
                .WithMany(c => c.ExamQuestions)
                .HasForeignKey(bc => bc.QuestionId);

        }
    }

}

