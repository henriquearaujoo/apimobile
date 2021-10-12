using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.DTO.Request
{
    public class KeyListItem
    {
        public int CodigoCooperativa { get; set; }
        public int NumeroConta { get; set; }
        public int IdChave { get; set; }
        public int CodigoTitular { get; set; }
        public string DescricaoChave { get; set; }
        public string SituacaoChave { get; set; }
        public bool Favorito { get; set; }
        public int CodigoTipoChave { get; set; }
        public string TipoChave { get; set; }
        public string NomeCooperado { get; set; }
        public string MotivoCancelamento { get; set; }
        public bool Portabilidade { get; set; }
        public bool Reivindicacao { get; set; }
        public bool ValidarPosse { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
