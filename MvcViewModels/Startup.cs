using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcViewModels.Model;
using MvcViewModels.Model.Data;
using MvcViewModels.Model.Data.Database;
using MvcViewModels.Model.Services;

namespace MvcViewModels
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RegistryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICitysRepo, DatabaseCitiesRepo>();
            services.AddScoped<ICitysService, CitysService>();
            services.AddScoped<ICountrysRepo, DatabaseCountrysRepo>();
            services.AddScoped<ICountryService, CountrysService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILanguageRepo, DatabaseLanguage>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=People}/{id?}");
                
            });
        }
    }
}
