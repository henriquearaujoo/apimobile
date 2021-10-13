using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Autentication.DTO.Request
{
    public class AuthenticationRequest
    {
        public Device Dispositivo { get; set; }
        public Password SenhasAutenticacao { get; set; }
    }
}
