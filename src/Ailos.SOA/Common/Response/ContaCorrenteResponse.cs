namespace Ailos.SOA.Common.Response
{
    public partial class ContaCorrenteResponse
    {
        public long CodigoConta { get; set; }
        public CooperativaResponse Cooperativa { get; set; }
    }

    public partial class CooperativaResponse
    {
        public long Codigo { get; set; }
    }
}