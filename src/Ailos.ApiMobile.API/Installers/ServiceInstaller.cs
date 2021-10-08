using Ailos.Pix.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ailos.ApiMobile.API.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IKeyService, KeyService>();
        }
    }
}
