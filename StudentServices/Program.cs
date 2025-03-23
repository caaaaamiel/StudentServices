
using Google.Protobuf.WellKnownTypes;
using StudentServices.Class;
using StudentServices.Services;

namespace StudentServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<AppDb>();

            builder.Services.AddTransient<StudentsServices>();

            builder.Services.AddHttpClient();

            builder.Services.AddCors(options =>
            {



                options.AddDefaultPolicy(

                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .WithMethods("GET", "POST")
                        .AllowAnyHeader();
                    });
            });

             
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();


            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
