using Ailos.SOA.CardAutorization.DTO.Common;
using System.Collections.Generic;

namespace Ailos.SOA.CardAutorization.DTO.Response
{
    public class AutorizacaoListaResponse
    {
        public List<DetalhesListaAutorizacao> Resultado { get; set; }
    }
}