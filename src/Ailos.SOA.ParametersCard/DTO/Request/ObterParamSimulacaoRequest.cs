using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Request
{
    public class ObterParamSimulacaoRequest : BaseModel
    {
        public ObterParamSimulacaoRequest(BaseModelSOARest baseModel)
            : base(baseModel)
        {
            Cooperativa = new Cooperativa(baseModel);
            Pessoa = new Pessoa(baseModel);
        }

        public Cooperativa Cooperativa { get; private set; }

        public Pessoa Pessoa { get; private set; }
    }
}