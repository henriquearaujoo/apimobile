namespace Ailos.SOA.Common.Card.Request
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