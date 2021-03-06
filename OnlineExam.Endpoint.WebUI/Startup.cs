using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OnlineExam.Domain.Contracts.Answers;
using OnlineExam.Domain.Contracts.Blogs;
using OnlineExam.Domain.Contracts.Choices;
using OnlineExam.Domain.Contracts.Courses;
using OnlineExam.Domain.Contracts.ExamQuestions;
using OnlineExam.Domain.Contracts.Exams;
using OnlineExam.Domain.Contracts.QuestionChoices;
using OnlineExam.Domain.Contracts.Questions;
using OnlineExam.Domain.Contracts.Results;
using OnlineExam.Domain.Core.AppUsers;
using OnlineExam.Infrastructures.DataLayer.Answers;
using OnlineExam.Infrastructures.DataLayer.Blogs;
using OnlineExam.Infrastructures.DataLayer.Choices;
using OnlineExam.Infrastructures.DataLayer.Common;
using OnlineExam.Infrastructures.DataLayer.Courses;
using OnlineExam.Infrastructures.DataLayer.ExamQuestions;
using OnlineExam.Infrastructures.DataLayer.Exams;
using OnlineExam.Infrastructures.DataLayer.QuestionChoices;
using OnlineExam.Infrastructures.DataLayer.Questions;
using OnlineExam.Infrastructures.DataLayer.Results;
using OnlineExam.Services.ApplicationService.MyPasswordValidator;

namespace OnlineExam.Endpoint.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IExamQuestionRepository, ExamQuestionRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuestionChoiceRepository, QuestionChoiceRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddDbContext<OnlineExamDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("OnlineExam")));

            services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator>();


            services.AddIdentity<AppUser, MyIdentityRole>(c =>
            {
                c.User.RequireUniqueEmail = false;
                c.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";
                c.Password.RequireLowercase = false;
                c.Password.RequireUppercase = false;
                c.Password.RequiredUniqueChars = 0;
                c.Password.RequiredLength = 0;
                c.Password.RequireNonAlphanumeric = false;

            }

            ).AddEntityFrameworkStores<OnlineExamDbContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
