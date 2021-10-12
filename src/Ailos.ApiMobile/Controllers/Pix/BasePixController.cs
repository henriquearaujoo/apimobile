using Ailos.ApiMobile.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Pix
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ServiceFilter(typeof(Wso2AuthenticationFilter))]
    public class BasePixController : ControllerBase
    {
    }
}
