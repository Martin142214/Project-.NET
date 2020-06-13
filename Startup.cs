using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("PlayerDBConnection")));

            //services.AddIdentity<IdentityUser, IdentityRole>().AddUserStore<AppDbContext>();
            services.AddScoped<IPlayerRepository, SQLPlayerRepository>();
            services.AddScoped<IProductRepository, SQLProductRepository>();
            services.AddScoped<ICommentRepository, SQLCommentRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc().AddXmlSerializerFormatters();
            //services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

            //    options.Filters.Add(new AuthorizeFilter(policy));
            //}).AddXmlSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
              Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new PathString("/Images")
            }) ;

            
   
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc(routes => {
            //    routes.MapRoute("default", "{Controller=Home}/{action=Details}/{id?}");

            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            
        }
    }
}
