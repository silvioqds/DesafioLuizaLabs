using API.LuizaLabs.Application.Helpers;
using API.LuizaLabs.Application.Interface;
using API.LuizaLabs.Application.Service;
using API.LuizaLabs.CrossCuting.Adapter;
using API.LuizaLabs.Data;
using API.LuizaLabs.Infra.IOC;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.LuizaLabs.Clientes
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
            //CONFIGURATION SQL SERVER
            var connection = Configuration["SQLConnection:SQLConnectionString"];
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            /////////////////////////////////////
            services.AddMemoryCache();
            services.AddControllers();

            //AUTOMAPPER
            services.AddAutoMapper(typeof(AutoMapping));

            // Configura secret                        
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));      
        }

        // INJEÇÃO DE DEPENDÊNCIA
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIOC());
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

            //POLITICAS DAS ROTAS GLOBAIS
            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            //JWT AUTH
            app.UseMiddleware<JWTMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
