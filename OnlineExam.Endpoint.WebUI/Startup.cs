using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Infrastructures.DataLayer.Answers;
using OnlineExam.Infrastructures.DataLayer.Choices;
using OnlineExam.Infrastructures.DataLayer.Common;
using OnlineExam.Infrastructures.DataLayer.Courses;
using OnlineExam.Infrastructures.DataLayer.ExamQuestions;
using OnlineExam.Infrastructures.DataLayer.Exams;
using OnlineExam.Infrastructures.DataLayer.QuestionChoices;
using OnlineExam.Infrastructures.DataLayer.Questions;

namespace OnlineExam.Endpoint.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<OnlineExamDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("OnlineExam")));
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IExamQuestionRepository, ExamQuestionRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuestionChoiceRepository, QuestionChoiceRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("UserContext")));
            //services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator>();


            //services.AddIdentity<AppUser, MyIdentityRole>(c =>
            //{
            //    c.User.RequireUniqueEmail = false;
            //    c.Password.RequireDigit = false;
            //    c.Password.RequireLowercase = false;
            //    c.Password.RequireUppercase = false;
            //    c.Password.RequiredUniqueChars = 0;
            //    c.Password.RequiredLength = 6;
            //    c.Password.RequireNonAlphanumeric = false;
            //}

            //).AddEntityFrameworkStores<UserDbContext>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
