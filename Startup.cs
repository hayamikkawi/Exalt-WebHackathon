using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using loginAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace loginAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUsers, MockUsers>();
            services.AddScoped<ICandidate, MockCandidate>();
            services.AddScoped<IInterview, MockInterviews>();
            services.AddScoped<ITime, MockTimes>();
            services.AddDbContext<UserDBContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TimeDBContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<HallDBContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<SeniorDBContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<InterviewDBContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<CandidateDBContext>(opt => opt.UseSqlServer(
           Configuration.GetConnectionString("secondConnection")));
            services.AddDbContext<UserDBContext>(ServiceLifetime.Transient);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(options =>

            {

                options.AddPolicy("MyCorsPolicy",

                builder =>

                {

                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();

                });

            });




            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseRouting();
            app.UseCors("MyCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
