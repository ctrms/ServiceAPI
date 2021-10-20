using Boyner.API.Context;
using Boyner.API.EFRepository;
using Boyner.API.EFUnitOfWork;
using Boyner.API.Interfaces;
using Boyner.API.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Boyner.API.Extensions;
using Boyner.API.CrossCuttingConcerns;
using Boyner.API.CrossCuttingConcerns.Caching;
using MediatR;
using Boyner.API.Services;

namespace Boyner.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMvc();
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbDataContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Boyner.API"));
            });
            services.AddScoped<DbContext, DbDataContext>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IProductService, ProductService>();
            var humanTypes = typeof(BaseQuery<>).GetTypeInfo().Assembly.DefinedTypes
              .Where(t => t.IsClosedTypeOf(typeof(BaseQuery<>)) && t.IsClass)
              .Select(p => p.AsType());

            foreach (var humanType in humanTypes)
            {
                services.AddScoped(humanType);
            }
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Boyner.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Boyner.API v1"));
            }
            ServiceTool.ServiceProvider = app.ApplicationServices;

            app.CustomExceptionMiddleware();

            app.UseCors("AllowOrigin");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
