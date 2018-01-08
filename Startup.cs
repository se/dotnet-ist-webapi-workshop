using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OurApi
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
            services.AddMvc();

            services.AddSwaggerGen(document =>
            {
                var contact = new Contact
                {
                    Email = "hey@selcukermaya.com",
                    Name = "Selçuk Ermaya",
                    Url = "https://selcukermaya.com"
                };
                var infov1 = new Info
                {
                    Contact = contact,
                    Title = "Todo v1 Documentation",
                    Description = "",
                    Version = "v1"
                };
                var infov11 = new Info
                {
                    Contact = contact,
                    Title = "Todo v1.1 Documentation",
                    Description = "",
                    Version = "v1.1"
                };

                document.SwaggerDoc("v1.1", infov11);
                document.SwaggerDoc("v1", infov1);

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Todo.xml");
                document.IncludeXmlComments(xmlPath);

                // Security Definitions
                document.AddSecurityDefinition("Client-Id", new ApiKeyScheme
                {
                    Name = "Client-Id",
                    Description = "",
                    Type = "apiKey",
                    In = "header"
                });
                document.AddSecurityDefinition("Client-Secret", new ApiKeyScheme
                {
                    Name = "Client-Secret",
                    Description = "",
                    Type = "apiKey",
                    In = "header"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "schema/{documentName}.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "help";
                c.SwaggerEndpoint("/schema/v1.1.json", "v1.1");
                c.SwaggerEndpoint("/schema/v1.json", "v1");
            });

            app.UseMvc();
        }
    }
}
