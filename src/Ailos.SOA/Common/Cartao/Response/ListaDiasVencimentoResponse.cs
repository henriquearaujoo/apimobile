using System.Collections.Generic;

namespace Ailos.SOA.Common.Cartao.Response
{
    public partial class ListaDiasVencimentoResponse
    {
        public List<DiaVencimento> DiaVencimento { get; set; }
    }

    public partial class DiaVencimento
    {
        public string Dia { get; set; }
    }
}