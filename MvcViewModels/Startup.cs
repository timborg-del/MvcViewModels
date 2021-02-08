using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcViewModels.Model;
using MvcViewModels.Model.Data;
using MvcViewModels.Model.Database;
using MvcViewModels.Model.Identity;
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
            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityPersonDbContext>()
            .AddDefaultTokenProviders();



            services.AddDbContext<IdentityPersonDbContext>(options =>
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

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                     builder =>
                     {
                         builder.WithOrigins("http://localhost:3000")//defualt uri for React (npm start)
                                             .AllowAnyMethod()
                                             .AllowAnyHeader();
                     });
            });

            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }

            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwagger();
            app.UseCors("MyAllowSpecificOrigins");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "React API V1");
            });

            app.UseAuthentication(); //checks if loged in
            app.UseAuthorization(); // Checks what userherarki

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=People}/{id?}");

            });
        }
    }
}

