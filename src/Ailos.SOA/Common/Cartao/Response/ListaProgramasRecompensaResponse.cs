using System.Collections.Generic;

namespace Ailos.SOA.Common.Card.Response
{
    public partial class ListaProgramasRecompensaResponse
    {
        public List<ProgramaRecompensa> ProgramaRecompensa { get; set; }
    }

    public partial class ProgramaRecompensa
    {
        public BeneficioProgramaRecompensa Beneficio { get; set; }
    }

    public partial class BeneficioProgramaRecompensa
    {
        public string Beneficio { get; set; }
    }
}