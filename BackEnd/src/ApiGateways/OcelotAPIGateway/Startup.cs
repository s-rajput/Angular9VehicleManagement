using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.Hosting;
using MMLib.Ocelot.Provider.AppConfiguration;
using Microsoft.OpenApi.Models;

namespace OcelotAPIGateway
{
    public class Startup
    {

        private readonly IConfiguration _cfg;

        public Startup(IConfiguration configuration)
        {
            _cfg = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddOcelot(_cfg); 
            //services.AddSwaggerForOcelot(_cfg);

            services.AddOcelot()
                .AddAppConfiguration();
            services.AddSwaggerForOcelot(_cfg);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.DownstreamSwaggerHeaders = new[]
                {
                        new KeyValuePair<string, string>("Key", "Value"),
                        new KeyValuePair<string, string>("Key2", "Value2"),
                    };

                opt.ServerOcelot = "/siteName/apigateway";
            })
                .UseOcelot()
                .Wait();


            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

      
    }
    
}
