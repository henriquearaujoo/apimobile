using Ailos.Http.Data;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Configurations
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IWso2DataService _wso2Service;
        private readonly IConfiguration _configuration;

        public AuthHeaderHandler(IWso2DataService wso2Service, IConfiguration configuration)
        {
            _wso2Service = wso2Service;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (TokenManager.Expired())
                await AuthorizeAsync(cancellationToken);

            var token = TokenManager.Token;

            request.Headers.Authorization = new AuthenticationHeaderValue(token.token_type, token.access_token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        private async Task AuthorizeAsync(CancellationToken cancellationToken)
        {
            var key = _configuration.GetValue<string>("WSO2:Key");
            var token = await _wso2Service.AuthorizeAsync(key, cancellationToken);

            TokenManager.SetTokenWSO2(token);
        }
    }
}
