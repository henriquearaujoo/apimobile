using Ailos.Http.Data;
using Ailos.Pix.Chave.Application;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Filters
{
    public class Wso2AuthenticationFilter : IAsyncActionFilter
    {
        private readonly IWso2DataService _wso2Service;
        private readonly IConfiguration _configuration;

        public Wso2AuthenticationFilter(IWso2DataService wso2Service, IConfiguration configuration)
        {
            _wso2Service = wso2Service;
            _configuration = configuration;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (TokenManager.Expired())
                await Autorizar();
            
            await next();
        }

        private async Task Autorizar()
        {
            var key = _configuration.GetValue<string>("WSO2:Key");
            var token = await _wso2Service.Authorize(key);
            TokenManager.SetTokenWSO2(token);
        }
    }
}
