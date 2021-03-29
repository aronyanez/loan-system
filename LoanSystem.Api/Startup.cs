using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using LoanSystem.Core.Entities;
using LoanSystem.Core.Interfaces;
using LoanSystem.Core.Services;
using LoanSystem.Infrastructure.Data;
using LoanSystem.Infrastructure.Filters;
using LoanSystem.Infrastructure.Repositores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LoanSystem.Api
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


            services.AddControllers(
               options =>
               {
                   options.Filters.Add<GlobalExceptionFilter>();
               }
                ).AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

           }).ConfigureApiBehaviorOptions(option =>
          {
              //option.SuppressModelStateInvalidFilter = true;
          });


            services.AddDbContext<LoanSystemContext>(
                        options => options.UseSqlServer(Configuration.GetConnectionString("LoanSystem"))
                );
            //Auto Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IService<User>, UserService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            services.AddMvc(options =>
           {
               options.Filters.Add<ValidationFilter>();
           }).AddFluentValidation(options =>
                  {
                      options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
