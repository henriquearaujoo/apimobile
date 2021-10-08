using Ailos.Pix.Services;
using ElmahCore.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ailos.ApiMobile.API
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
            // Response personalizado para a vailidação dos requests
            IActionResult InvalidModelStateResponseFactory(ActionContext context)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(kvp => new
                    {
                        FieldName = kvp.Key,
                        Messages = kvp.Value.Errors.Select(x => x.ErrorMessage)
                    });

                return new BadRequestObjectResult(errors);
            }

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory;
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerGen(c =>
            {
                var fullPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml");

                c.IncludeXmlComments(fullPath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ailos.ApiMobile.API", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Ailos.ApiMobile.API", Version = "v2" });
            });

            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddFluentValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
                options.RegisterValidatorsFromAssembly(Assembly.Load("Ailos.Pix"));
                //options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddElmah();

            services.AddScoped<IKeyService, KeyService>();

            //Utilizar o installer pattern
            services.AddInstallers(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ailos.ApiMobile.API v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Ailos.ApiMobile.API v2");
                });
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseElmah();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
