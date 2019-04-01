using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Cucr.CucrSaas.App.DataAccess;
using Cucr.CucrSaas.App.Filters;
using Cucr.CucrSaas.App.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
namespace Cucr
{
    /// <summary>
    /// 程序启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 程序启动类的构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 程序配置对象
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(SingleLoginFilter));
            });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            //
            // var connection = "Server=39.97.180.241;Database=ef;User=root;Password=yj704104;";

            //Allow Zero Datetime=True
            var connection = "Data Source=47.100.63.224;Database=cucrsaasdb;User Id=root;Password=8US7DJ3WB5v;Convert Zero Datetime=True;Allow User Variables=True";
            //var connection = @"Server=localhost;Initial Catalog=master;Integrated Security=True";
            services
                .AddDbContext<OAContext>(options => options.UseMySql(connection))
                .AddDbContext<SysContext>(options => options.UseMySql(connection))

            ;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddHttpClient();
            // services.AddSwaggerDocument ();
            services.AddSwaggerDocument(config =>
            {

                config.Version = "v1";
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
                config.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT", new SwaggerSecurityScheme
                {
                    Type = SwaggerSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = SwaggerSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}. You can get a JWT token from /Authorization/Authenticate."
                }));

                // Post process the generated document
                config.PostProcess = d => d.Info.Title = "创联科技Sass服务";
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ISmsService, SmsService>();

        }

        /// <summary>
        ///This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseCors("AllowAllOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            var settings = new SwaggerDocumentMiddlewareSettings();
            settings.PostProcess = (document, request) =>
            {

                // document.BaseUrl = "http://192.168.1.99:5000";
                document.Info.Version = "v3";

            };
            app.UseSwaggerUi3();

            app.UseSwagger();

            // app.UseSpa (spa => {
            //     // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //     // see https://go.microsoft.com/fwlink/?linkid=864501
            //     spa.Options.SourcePath = "ClientApp";
            //     if (env.IsDevelopment ()) {
            //         spa.UseAngularCliServer (npmScript: "start");
            //     }
            // });
        }

    }
}