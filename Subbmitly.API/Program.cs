
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Subbmitly.Application.Interfaces;
using Subbmitly.Application.Services;
using Subbmitly.Infrastructure;
using Subbmitly.Infrastructure.Repos;
using System.Text.Json.Serialization;

namespace Subbmitly.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularFrontEnd",
                    policy => policy.AllowAnyOrigin() // or use .AllowAnyOrigin() for testing
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // Add services to the container.
            builder.Services.AddScoped<IUserProfileService, UserProfileService>();
            builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<RecruitMgmtDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DbContext"),
                    providerOptions =>
                    {
                        providerOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null);
                    });
            });


            var app = builder.Build();
            app.UseCors("AllowAngularFrontEnd");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
