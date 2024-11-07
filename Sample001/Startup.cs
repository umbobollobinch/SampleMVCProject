using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample001.DBContexts;
using Sample001.Services;
using Sample001.Services.Account;
// definition for Cookie auths -----------------------
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Sample001.Services.Logging;
// ---------------------------------------------------

namespace Sample001
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //-------------------------------------------------------
        //METHOD-n is how to validate [AllowAnonymous] attribute 
        //-------------------------------------------------------
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                // METHOD-3 add AuthorizeFilter ... for UseMvc
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.EnableEndpointRouting = false;
            });

            services.AddDbContext<SchoolDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBContext"));
            });
        
            services.AddDbContext<AccountDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ADBContext"));
            });

            services.AddHttpClient();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IBasicServices, BasicServices>();
            services.AddScoped<ICovidServices, CovidServices>();
            services.AddScoped<ILoggingServices, LoggingServices>();
            services.AddApplicationInsightsTelemetry();
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
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");

            app.UseHttpsRedirection(); // http to https
            app.UseStaticFiles(); // it can use files in "wwwroot" folder.

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
