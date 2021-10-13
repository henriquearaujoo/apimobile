using Ailos.SOA.Common.Response;
using System.Collections.Generic;

namespace Ailos.SOA.Common.Cartao.Response
{
    public class ListaEnderecosCooperativaResponse
    {
        public List<ListaEnderecosCooperativaEndereco> Endereco { get; set; }
    }

    public partial class ListaEnderecosCooperativaEndereco
    {
        public TipoDescricaoResponse PostoAtendimento { get; set; }
        public PessoaContatoEnderecoCooperativa PessoaContatoEndereco { get; set; }
    }

    public partial class PessoaContatoEnderecoCooperativa
    {
        public string TipoENomeLogradouro { get; set; }
    }
}