using Ailos.SOA.Common;

namespace Ailos.SOA.Card.DTO.Request
{
    public class EmitenteRequest : BaseModel
    {
        public EmitenteRequest(BaseModelSOARest baseModel) : base(baseModel)
        {
            ContaCorrente = new ContaCorrente(baseModel);
        }

        public ContaCorrente ContaCorrente { get; private set; }
    }
}