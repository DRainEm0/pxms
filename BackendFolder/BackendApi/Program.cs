using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Wrapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<pxinxnmyschxxldxrsContext>(
            options => options.UseSqlServer(
                    "Server=DESKTOP-TEJVL2L; Database=testset; User Id=sa; Password=123;"));
            
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Интернет-магазин pxms",
                    Description = "wear store",
                    Contact = new OpenApiContact
                    {
                        Name = "vk",
                        Url = new Uri("https://vk.com/immortalpainhihihihi")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "лицензия официальная 100%+100%",
                        Url = new Uri("https://mynickname.com/id1782851")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

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