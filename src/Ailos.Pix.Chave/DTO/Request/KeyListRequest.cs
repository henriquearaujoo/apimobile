using Ailos.Common.DTO.Request;
using System;
using System.Collections.Generic;

namespace Ailos.Pix.Chave.DTO.Request
{
    public class KeyListRequest : BaseRequest
    {
        public int IdChave { get; set; }
        public string DescricaoChave { get; set; }
        public int CodigoEnviado { get; set; }
        public int IdTransferePosse { get; set; }
        public int CodigoTipoChave { get; set; }
        public IEnumerable<int> SituacaoChave { get; set; }
    }
}
