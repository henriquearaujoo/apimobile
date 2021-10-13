using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public class ObterListaMotBloqueioOfertaCartaoRequest
    {
        public ObterListaMotBloqueioOfertaCartaoRequest()
        {
            CanalRelacionamento = new CanalRelacionamento();
        }

        public CanalRelacionamento CanalRelacionamento { get; private set; }
    }
}