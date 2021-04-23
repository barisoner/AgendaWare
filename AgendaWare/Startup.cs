using AgendaWareData.Entities;
using AgendaWareData.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaWare
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSession();
            services.AddMvc();

            //Barýþ: Burayý config altýnda yazmam gerektiðini biliyorum. Ancak çok hata aldýðýmdan dolayý burada býrakmak durumunda kaldým.
            services.AddDbContext<AgendaWareDbContext>(option => option.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = AgendaWareDB; Trusted_Connection = True;MultipleActiveResultSets = True"));

            services.AddControllers(options => options.EnableEndpointRouting = false);

            services.AddTransient<IEventRepository, EventRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{Controller=Home}/{Action=Index}/{id?}"
                    );
            });

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 401)
                {
                    app.Use(async (context, next) =>
                    {
                        context.Request.Path = "/UnAuthAccess";
                        await next();
                    });
                }
                if (context.HttpContext.Response.StatusCode == 404)
                {
                    app.Use(async (context, next) =>
                    {
                        context.Request.Path = "/NotFound";
                        await next();
                    });
                }
                if (context.HttpContext.Response.StatusCode == 500)
                {
                    app.Use(async (context, next) =>
                    {
                        context.Request.Path = "/UnExpected";
                        await next();
                    });
                }
            });
        }
    }
}
