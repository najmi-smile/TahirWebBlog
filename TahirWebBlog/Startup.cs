using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using TahirWebBlogDbContext;


using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TahirWebBlog
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
            services.AddDbContext<AppDatabase>(options => options.UseSqlServer("Server=(localdb)\\db;Database=TahirWebBlog;User=guest; Password=guest"));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                //  Below vode is for resolving the area controller naming conflict
                //var namespaces = new[] { typeof(PostsController).Namespace };
                //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                //routes.MapRoute("Login", "login", new { Controller = "Auth", Action = "Login" }, namespaces);
                //routes.MapRoute("Logout", "logout", new { Controller = "Auth", Action = "Logout" }, namespaces);
                //routes.MapRoute("Home", "", new { Controller = "Posts", Action = "Index" }, namespaces);

                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Users}/{action=Get}/{id?}"
                );
            });
            app.UseMvc();
        }
    }
}
