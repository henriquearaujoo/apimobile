using Ailos.SOA.Card.DTO.Request;
using Ailos.SOA.Cartao.Application;
using Ailos.SOA.Common.Cartao.Response;
using Ailos.SOA.DTO.Card.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Api.SOA.Card
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [Route("api/Cartao/TermoAdesao")]
        public async Task<TermoAdesaoCartaoResponse> GetAdhesionTerm(ObterTermoAdesaoRequest request)
        {
            return await _cardService.GetAdhesionTerm(request);
        }

        [HttpGet]
        [Route("api/Cartao/PermissaoMenu")]
        public async Task<PermissoesCartaoResponse> MenuPermissions()
        {
            return await _cardService.TakeMenuPermissions();
        }
    }
}