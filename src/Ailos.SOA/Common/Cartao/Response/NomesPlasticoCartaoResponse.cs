using System.Collections.Generic;

namespace Ailos.SOA.Common.Card.Response
{
    public class NomesPlasticoCartaoResponse
    {
        public IEnumerable<string> NomesTitular { get; set; }
        public IEnumerable<string> NomesEmpresa { get; set; }
    }
}