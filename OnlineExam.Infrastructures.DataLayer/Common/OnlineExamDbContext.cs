using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Core.Answers;
using OnlineExam.Domain.Core.Choices;
using OnlineExam.Domain.Core.Courses;
using OnlineExam.Domain.Core.ExamQuestions;
using OnlineExam.Domain.Core.Exams;
using OnlineExam.Domain.Core.QuestionChoices;
using OnlineExam.Domain.Core.Questions;
using OnlineExam.Infrastructures.DataLayer.Answers;
using OnlineExam.Infrastructures.DataLayer.Choices;
using OnlineExam.Infrastructures.DataLayer.Courses;
using OnlineExam.Infrastructures.DataLayer.ExamQuestions;
using OnlineExam.Infrastructures.DataLayer.Exams;
using OnlineExam.Infrastructures.DataLayer.QuestionChoices;
using OnlineExam.Infrastructures.DataLayer.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Infrastructures.DataLayer.Common
{
    public class OnlineExamDbContext : DbContext
    {
        public OnlineExamDbContext(DbContextOptions<OnlineExamDbContext> options) : base(options)
        {

        }



        public DbSet<Answer> Answers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<QuestionChoice> QuestionChoices { get; set; }
        public DbSet<Question> Questions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new ChoiceConfig());
            modelBuilder.ApplyConfiguration(new ExamConfig());
            modelBuilder.ApplyConfiguration(new QuestionConfig());
            modelBuilder.ApplyConfiguration(new ExamQuestionsConfig());
            modelBuilder.ApplyConfiguration(new QuestionChoiceConfig());
        }
    }
}