using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MiAngular.Models;

namespace MiAngular
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // var connection = @"Server=15.0.2000.5;DataBase=AngularChat; Trusted_Connection=True; ConnectRetryCount=0";
            // //var connection = "Trusted_connection=true; Data Source = localhost; database=AngularChat; user=UsuarioBD;Password=UsuarioBD; Integrated Security = True";
            //// services.AddDbContext<MyDBContext>(options => options.UseSqlServer(connection));

            // services.AddDbContext<MyDBContext>(cfg =>
            // {
            //     cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            // });

            //services.AddControllers();

            //services.AddDbContext<MyDBContext>(options =>
            //    {
            //        options.UseSqlServer(Configuration.GetConnectionString("AngularChat"));
            //    });

            // var connection = @"Data Source=localhost; Password =UsuarioBD;User ID =UsuarioBD;  Initial Catalog=Facturacion;MultipleActiveResultSets=True;";
            var connection = @"Server=localhost;DataBase=AngularChat; Trusted_Connection=True; ConnectRetryCount=0";
            services.AddDbContext<MyDBContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
