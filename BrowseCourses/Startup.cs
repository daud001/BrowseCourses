using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BrowseCourses.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace BrowseCourses {

    public class Startup {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:BrowseCoursesCourses:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>options.UseSqlServer(Configuration["Data:BrowseCoursesIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();


            services.AddTransient<ICourseRepository, EFCourseRepository>();
            services.AddScoped<Plan>(sp => SessionPlan.GetPlan(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPlanDetailRepository, EFPlanDetailRepository>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: null,
                template: "{category}/Page{CoursePage:int}",
                defaults: new { controller = "Course", action = "List" }
                );

                routes.MapRoute(
                name: null,
                template: "Page{CoursePage:int}",
                defaults: new { controller = "Course", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                name: null,
                template: "{category}",
                defaults: new { controller = "Course", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                name: null,
                template: "",
                defaults: new { controller = "Course", action = "List", productPage = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

                /*
                routes.MapRoute(
                    name: "pagination",
                    template: "Courses/Page{CoursePage}",
                    defaults: new { Controller = "Course", action = "List" });
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Course}/{action=List}/{id?}"); 
                */
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
