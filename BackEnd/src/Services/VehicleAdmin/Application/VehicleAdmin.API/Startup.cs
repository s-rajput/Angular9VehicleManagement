using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using VehicleAdmin.API.Infrastructure.AutofacModules;
using VehicleAdmin.API.Infrastructure.Filters;
using VehicleAdmin.Application.Queries; 
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace VehicleAdmin.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers();

            services.AddControllersWithViews()
            .AddNewtonsoftJson();

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim("rol", "api-access"));
            });

            //services.AddAutoMapper(typeof(Startup));

            services
               // .AddCustomMvc()
                .AddCustomSwagger(Configuration);


            //services

            services.AddSingleton<IVehicleRepository,
               VehicleAdmin.Infrastructure.Repositories.VehicleRepository>();

            services.AddSingleton<VehicleAdmin.Infrastructure.Repositories.VehicleContext>();

            services.AddDbContext<VehicleAdmin.Infrastructure.Repositories.VehicleContext>(db => db.UseInMemoryDatabase("DemoDb"));

            services.AddSingleton<IVehicleQueries, VehicleQueries>();

            //configure autofac

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {

            app.UseCors("AllowAll");



            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //swagger
            var vd = Configuration["VirtualDirectory"];
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(vd) ? vd : string.Empty) }/swagger/v1/swagger.json", "Vehicle.API V1");
                   c.InjectStylesheet("/swagger-ui/custom.css");
               });





            //var ping.IsNullOrEmpty(pathBase))
            //{athBase = Configuration["PATH_BASE"];
            //if (!str
            //    loggerFactory.CreateLogger("init").LogDebug($"Using PATH BASE '{pathBase}'");
            //    app.UsePathBase(pathBase);
            //}


            //app.UseCors("AllowAll");

            ////app.UseMvcWithDefaultRoute();
            //SetUpRouting(app);
            //app.UseSwagger()
            //   .UseSwaggerUI(c =>
            //   {
            //       c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "VehicleAdmin.API V1");
            //      // c.OAuthClientId("VehicleAdminswaggerui");
            //      // c.OAuthAppName("VehicleAdmin Swagger UI");
            //   });

           
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        private void SetUpRouting(IApplicationBuilder app)
        {
            //set up mandatory registrations for .net core 3.0
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

        }

    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                              //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
         

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VehicleAdmin API",
                    Version = "v1",
                    Description = "The Vehicle back end Service HTTP API"
                });
                options.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblyOf<API.Controllers.CreateVehicleBulkCmdExample>();
            return services;
        }
 
    }
}

 