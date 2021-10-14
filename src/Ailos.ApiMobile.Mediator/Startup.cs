using Ailos.Http.Data;
using Ailos.Pix.Cadastro.Data;
using Ailos.Pix.Chave.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;
using System;
using System.Net.Http;

namespace Ailos.ApiMobile.Mediator
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ailos.ApiMobile.Mediator", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            var url = Configuration.GetValue<string>("WSO2:BaseURL");
            var environment = Configuration.GetValue<string>("WSO2:Environment");

            Action<HttpClient> clientConfiguration =
                options => options.BaseAddress = new Uri(url + environment);

            services.AddRefitClient<IWso2DataService>()
                .ConfigureHttpClient(options => options.BaseAddress = new Uri(url));

            services.AddRefitClient<IKeyDataService>()
                .ConfigureHttpClient(clientConfiguration);

            services.AddRefitClient<IRegistrationDataService>()
                .ConfigureHttpClient(clientConfiguration)
                .AddHttpMessageHandler<AuthHeaderHandler>();

            services.AddTransient<AuthHeaderHandler>();

            services.AddShowRegisteredServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ailos.ApiMobile.Mediator v1"));

                app.UseShowRegisteredServices();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
