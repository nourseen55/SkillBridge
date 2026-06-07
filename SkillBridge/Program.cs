
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SkillBridge.API.Filters;
using SkillBridge.API.Middlewares;
using SkillBridge.Application.Interfaces.Services;
using SkillBridge.Application.Interfaces.UnitOfWork;
using SkillBridge.Application.Services;
using SkillBridge.Application.Validators.Courses;
using SkillBridge.Infrastructure.Data;
using SkillBridge.Infrastructure.UnitOfWork;

namespace SkillBridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });   
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                );
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseDtoValidator>();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            var app = builder.Build();
            app.UseExceptionHandler(_ => { });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
