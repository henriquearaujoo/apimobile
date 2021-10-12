using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Pix.DTO
{
    public class BaseRequest
    {
        public int CodigoCooperativa { get; set; }
        public int? CodigoTitular { get; set; }
        public int NumeroConta { get; set; }
        public int CodigoCanal { get; set; }
        public long? IdDispositivo { get; set; }
        public string IpAcionamento { get; set; }
        public long CpfOperador { get; set; }
        public string CodigoOperador { get; set; }
        public string SecretKey { get; set; }
    }
}
