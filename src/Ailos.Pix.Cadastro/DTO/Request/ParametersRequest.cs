using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.Cadastro.DTO.Request
{
    public class ParametersRequest
    {
        public int CodigoCooperativa { get; set; }
        public int CodigoCanal { get; set; }
        public string IpAcionamento { get; set; }
        public string CodigoOperador { get; set; }
        public int IdDispositivo { get; set; }
    }
}
