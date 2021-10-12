using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.DTO.Request
{
    public class KeyListResponse
    {
        public List<KeyListItem> Chaves { get; set; }
        public int QuantidadeChavesAtivas { get; set; }
        public int QuantidadeMaximaChaves { get; set; }
        public bool QuantidadeMaximaChavesAtingida { get; set; }
    }
}
