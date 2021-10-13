using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public class ObterListaMotivoNegCartaoRequest
    {
        public ObterListaMotivoNegCartaoRequest()
        {
            CanalRelacionamento = new CanalRelacionamento();
        }

        public CanalRelacionamento CanalRelacionamento { get; private set; }
    }
}