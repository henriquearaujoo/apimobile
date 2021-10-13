using System.Collections.Generic;

namespace Ailos.SOA.PreApprovedCard.DTO.Response
{
    public class EnderecoEntregaCartaoResponse
    {
        public bool EnviaCooperado { get; set; }
        public int PrevisaoEntrega { get; set; }
        public EnderecoEntregaCartao EnderecoPACooperado { get; set; }
        public IEnumerable<EnderecoEntregaCartao> EnderecosCooperado { get; set; }
        public IEnumerable<EnderecoEntregaCartao> EnderecosCooperativas { get; set; }
    }

    public class EnderecoEntregaCartao
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string Endereco { get; set; }
    }
}