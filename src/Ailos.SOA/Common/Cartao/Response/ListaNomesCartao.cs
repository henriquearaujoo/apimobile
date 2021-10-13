using System.Collections.Generic;

namespace Ailos.SOA.Common.Cartao.Response
{
    public partial class ListaEmbossadorasResponse
    {
        public List<PessoaEmbossadora> Pessoa { get; set; }
    }

    public partial class PessoaEmbossadora
    {
        public string RazaoSocialOuNome { get; set; }
    }

    public partial class ListaNomesImpressosResponse
    {
        public List<string> NomeImpresso { get; set; }
    }
}