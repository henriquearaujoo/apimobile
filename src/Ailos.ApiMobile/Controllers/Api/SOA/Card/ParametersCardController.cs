using Ailos.SOA.ParametersCard.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ailos.ApiMobile.Controllers.Api.SOA.Card
{
    public class ParametersCardController : Controller
    {
        private readonly IParametersCardService _parametersCardService;

        public ParametersCardController(IParametersCardService parametersCardService)
        {
            _parametersCardService = parametersCardService;
        }
    }
}