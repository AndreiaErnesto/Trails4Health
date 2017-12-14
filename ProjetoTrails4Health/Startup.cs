using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTrails4Health.Data;
using ProjetoTrails4Health.Models;
using ProjetoTrails4Health.Services;

namespace ProjetoTrails4Health
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
            // Add framework services.
            services.AddDbContext<Trails4HealthLoginsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConectionStringLoginsTrails4Health")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Trails4HealthLoginsDbContext>()
                .AddDefaultTokenProviders();


            //Ficheiro .json Database=Books - criação de base de dados com este nome
            //Ficheiro .json MultipleActiveResultSets - vários utilizadores a aceder com diferentes querys
            services.AddDbContext<Trails4HealthDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("ConectionStringTrails4Health"))
            );

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            //ADICIONAR SEEDDATA - comentar quando for necessário fazer migrações
            var serviceProvider = services.BuildServiceProvider();
            SeedData.EnsurePopulated(serviceProvider);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
