using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotNetCoreWebAPI.HelperMethods;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using Microsoft.AspNetCore.Mvc;
using Managers.Abstract;
using Managers.Concrete;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Data.Concrete;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Newtonsoft.Json;

namespace DotNetCoreWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddReact();
            services.AddCors(opt => opt.AddPolicy("AllowAll", p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonFormatters().AddApiExplorer();

            services.AddDbContext<MyDatabaseContext>(options => {
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("MyDatabase"));
                //options.UseNetTopologySuite();
            });

            services.AddDbContext<MySecondDatabaseContext>(options => {
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("MySecondDatabase"));
                //options.UseNetTopologySuite();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My Swagger", Version = "v1", Description="Sheri Begum", Contact=new Swashbuckle.AspNetCore.Swagger.Contact { Name="Raja Kondla", Email="rajakondla@gmail.com" } });
            });

            services.AddHealthChecks().AddDbContextCheck<MyDatabaseContext>();

            // services.Configure<RazorViewEngineOptions>(options=> { options.ViewLocationExpanders.Add(new CustomizeLocation()); });
            var builder = new ContainerBuilder();
            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<RoleManager>().As<IRoleManager>();
            builder.RegisterType<UserRoleManager>().As<IUserRoleManager>();
            builder.RegisterType<OrderManager>().As<IOrderManager>();
            builder.RegisterType<OrderProductManager>().As<IOrderProductManager>();
            builder.RegisterType<GasStationManager>().As<IGasStationManager>();
           
            builder.Populate(services);

            var container = builder.Build();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.InstanceName = "127.0.0.1";//Configuration.GetValue<string>("redis:name");
            //    options.Configuration = "master";//Configuration.GetValue<string>("redis:host");
            //});

            //services.AddSession();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            app.UseCustomizedMiddleWear();
            
            //app.UseReact(config => {

            //    config.AddScript("~/Script/Components/Tutorial.jsx");

            //});

            //app.UseStaticFiles();
            string cacheAge = "600";
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1"); });
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
            //    RequestPath = "/StaticFiles",
            //    OnPrepareResponse = (ctx) => { ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cacheAge}"); }
            //});

            //app.UseCors("AllowAll");
            //app.UseMvc();
        }
    }
}
