using Ailos.ApiMobile.Filters;
using Ailos.Autentication.Application;
using Ailos.Http.Data;
using Ailos.Pix.Cadastro.Application;
using Ailos.Pix.Chave.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ailos.ApiMobile.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Wso2AuthenticationFilter>();
            services.AddTransient<AuthHeaderHandler>();
            services.AddScoped<IKeyService, KeyService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
