using Ailos.ApiMobile.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Ailos.ApiMobile.Controllers.Pix
{
    [ServiceFilter(typeof(Wso2AuthenticationFilter))]
    public class BasePixController : ControllerBase
    {
    }
}
