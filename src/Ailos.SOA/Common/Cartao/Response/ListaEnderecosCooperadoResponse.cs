using Ailos.SOA.Common.Response;
using System.Collections.Generic;

namespace Ailos.SOA.Common.Cartao.Response
{
    public class ListaEnderecosCooperadoResponse
    {
        public List<ListaEnderecosCooperadoEndereco> Endereco { get; set; }
        public int TipoEnvio { get; set; }
    }

    public partial class ListaEnderecosCooperadoEndereco
    {
        public TipoResponse PostoAtendimento { get; set; }
        public PessoaContatoEnderecoCooperado PessoaContatoEndereco { get; set; }
    }

    public partial class PessoaContatoEnderecoCooperado
    {
        public TipoDescricaoResponse TipoEndereco { get; set; }
        public string TipoENomeLogradouro { get; set; }
    }
}