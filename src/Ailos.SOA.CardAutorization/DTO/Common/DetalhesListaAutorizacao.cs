using Ailos.SOA.Common.Card;
using System;

namespace Ailos.SOA.CardAutorization.DTO.Common
{
    public class DetalhesListaAutorizacao
    {
        public string NumeroProposta { get; set; }
        public string Modalidade { get; set; }
        public double LimiteContratado { get; set; }
        public DateTime DataContratacao { get; set; }
        public StatusCartao Status { get; set; }
    }
}