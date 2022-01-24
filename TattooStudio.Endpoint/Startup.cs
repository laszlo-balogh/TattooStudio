using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooStudio.Data;
using TattooStudio.Data.Settings;
using TattooStudio.Logic;
using TattooStudio.Repository;

namespace TattooStudio.Endpoint
{
    public class Startup       
    {
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ITattooRepository, TattooRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IWorkRepository, WorkRepository>();
            services.AddTransient<ITattooLogic, TattooLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ITaskLogic, TaskLogic>();           
            services.AddTransient<TattooStudioDbContext, TattooStudioDbContext>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var configSection = Configuration.GetSection("DataBase");
            DatabaseSettings databaseSettings = new DatabaseSettings();
            
            configSection.Bind(databaseSettings);


            services.AddSingleton<DatabaseSettings>(databaseSettings);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
