using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Ailos.ApiMobile.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                var fullPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml");

                c.IncludeXmlComments(fullPath);

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ailos.ApiMobile", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Ailos.ApiMobile", Version = "v2" });
            });
        }
    }
}
