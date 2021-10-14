using Ailos.ApiMobile.Configurations;
using Ailos.Autentication.Data;
using Ailos.Common.Data;
using Ailos.Http.Data;
using Ailos.Pix.Cadastro.Data;
using Ailos.Pix.Chave.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Net.Http;

namespace Ailos.ApiMobile.Installers
{
    public class RefitInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("WSO2:BaseURL");
            var environment = configuration.GetValue<string>("WSO2:Environment");

            void ClientConfiguration(HttpClient options) => options.BaseAddress = new Uri(url + environment);

            services.AddRefitClient<IWso2DataService>()
                .ConfigureHttpClient(options => options.BaseAddress = new Uri(url));

            services.AddRefitClient<IKeyDataService>()
                .ConfigureHttpClient(ClientConfiguration);

            services.AddRefitClient<IRegistrationDataService>()
                .ConfigureHttpClient(ClientConfiguration)
                .AddHttpMessageHandler<AuthHeaderHandler>();

            services.AddRefitClient<ICooperadoDataService>()
                .ConfigureHttpClient(clientConfiguration)
                .AddHttpMessageHandler<AuthHeaderHandler>();
            
            services.AddRefitClient<IAuthenticationDataService>()
                .ConfigureHttpClient(clientConfiguration)
                .AddHttpMessageHandler<AuthHeaderHandler>();
        }
    }
}
