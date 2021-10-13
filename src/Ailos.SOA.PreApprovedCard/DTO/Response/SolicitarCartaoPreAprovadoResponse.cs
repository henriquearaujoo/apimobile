namespace Ailos.SOA.PreApprovedCard.DTO.Response
{
    public partial class SolicitarCartaoPreAprovadoResponse
    {
        public PropostaCartaoSolicitarResponse PropostaCartao { get; set; }
    }

    public partial class PropostaCartaoSolicitarResponse
    {
        public string IdentificadorProposta { get; set; }
    }
}