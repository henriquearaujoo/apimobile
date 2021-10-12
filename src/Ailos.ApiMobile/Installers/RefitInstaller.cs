using Ailos.Http.Data;
using Ailos.Pix.Cadastro.Data;
using Ailos.Pix.Chave.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.IO;
using System.Net.Http;

namespace Ailos.ApiMobile.Installers
{
    public class RefitInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("WSO2:BaseURL");
            var environment = configuration.GetValue<string>("WSO2:Environment");

            Action<HttpClient> clientConfiguration = 
                options => options.BaseAddress = new Uri(url + environment);

            services.AddRefitClient<IWso2DataService>()
                .ConfigureHttpClient(options => options.BaseAddress = new Uri(url));
                           
            services.AddRefitClient<IKeyDataService>()
                .ConfigureHttpClient(clientConfiguration);

            services.AddRefitClient<IRegistrationDataService>()
                .ConfigureHttpClient(clientConfiguration)
                .AddHttpMessageHandler<AuthHeaderHandler>();
        }
    }
}
