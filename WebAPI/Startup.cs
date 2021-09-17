using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Core.Application.Mapping;
using Infrastructure.Persistence;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using WebAPI.Authentication;
using WebAPI.Middleware;

namespace WebAPI
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            #region Mapping configuration

            services.AddAutoMapper(cfg =>
            {
                cfg.DisableConstructorMapping();
                cfg.AddExpressionMapping();
            }, typeof(ModelMappingProfile));

            #endregion

            #region Services configuration

            services.AddPersistenceServices();
            services.AddInfrastructureServices();

            #endregion

            #region Database configuration

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            #endregion

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandleMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
