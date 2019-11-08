using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgramAcad.Infra.Data.Context;
using Microsoft.OpenApi.Models;
using ProgramAcad.Infra.IoC;
using System.Reflection;
using System;
using System.IO;
using Refit;
using ProgramAcad.Services.Modules.Compiling.RefitInterfaces;

namespace ProgramAcad.API.Presentation
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            ConfigurationRoot = builder.Build();
        }

        public IConfigurationRoot ConfigurationRoot { get;  }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(configs =>
            {
                configs.AddPolicy("AllowAnyOrigin", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();                    
                });
            });
            services.AddControllers();
            services.AddDbContext<ProgramAcadContext>(options =>
            {
                options.UseSqlServer(ConfigurationRoot.GetConnectionString("ProgramAcadContext"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProgramAcad Web API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddRefitClient<ICompilerApiCall>()                        
                        .ConfigureHttpClient(c =>
                        {
                            c.BaseAddress = new Uri("https://api.jdoodle.com/v1");
                            c.Timeout = TimeSpan.FromMinutes(5);
                            c.DefaultRequestHeaders.Remove("charset");                           
                        });            
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(configs =>
            {
                configs.SwaggerEndpoint("/swagger/v1/swagger.json", "ProgramAcad Web API v1");                
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
