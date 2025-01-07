using ConferenceManager.Data;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConferenceManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<EventsRepository>();
            builder.Services.AddScoped<EventsService>();
            builder.Services.AddSingleton<SpeakerRepository>();
            builder.Services.AddScoped<SpeakerService>();
            builder.Services.AddSingleton<AttendeeRepository>();
            builder.Services.AddScoped<AttendeeService>();
            builder.Services.AddScoped<UserService>(); 


            var key = Encoding.UTF8.GetBytes("GTNONCE9YBYyfRDULsbHP2m8CPFUZxwWzYAAmyA4MhkNt25s10TIcaWg3m93cZdwKTl5GpjnhJ/K6vxu8dqCSnjbQ6KCaLa8vwcjolbXWNnC43pwjqsqY76Sm66cvwPj3pwUtrVJ3+Zf79TmtI8IhKm9oAtozCVzH+wCPZ0JCZ3QDyfP8CBM+7O6Qf/cufgGBfsURnZ5Eac7/z2yK33p6tsgOhEQfDxhgt37ZwVxXAQIt+5M8RK5TD46eBaEsq30hwoecea0Xm+do2bZWVON6EKz4QDuMw9+HE/ZL5XrLWxzua7snXtZPUA6s2wQnkLSIbGXjbhlCb3N+uKew0aEBSmZi+XsVvaRAivWC8JlFks=");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "Nick&Rachel",
                    ValidateAudience = true,
                    ValidAudience = "ConferenceManager",
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    RoleClaimType = "roles",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                options.MapInboundClaims = false;
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
