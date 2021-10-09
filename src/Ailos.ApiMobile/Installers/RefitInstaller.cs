using Ailos.Pix.Application.Refit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Ailos.ApiMobile.Installers
{
    public class RefitInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IKeyService>()
                .ConfigureHttpClient(options => 
                {
                    options.BaseAddress = new Uri("https://localhost:5001");
                });
        }
    }
}
