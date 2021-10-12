using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Cadastro.DTO.Response
{
    public class ParametersResponse
    {
        public int CodigoCooperativa { get; set; }
        public string SituacaoProduto { get; set; }
        public int QuantidadeMaximaChavesPf { get; set; }
        public int QuantidadeMaximaChavesPj { get; set; }
        public int QuantidadeDiasDesativacaoChave { get; set; }
        public double ValorMaximoTransacaoPf { get; set; }
        public double ValorMaximoTransacaoPj { get; set; }
        public string HorarioInicioAtualizacaoDict { get; set; }
        public string HorarioFinalAtualizacaoDict { get; set; }
    }
}
