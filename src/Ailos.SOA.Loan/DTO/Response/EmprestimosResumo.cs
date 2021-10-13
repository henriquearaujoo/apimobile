using Ailos.Ailos.SOA.Loan.DTO.Common;
using System.Collections.Generic;

namespace Ailos.SOA.Loan.DTO.Response
{
    /// <summary>
    /// Objeto que representa uma lista de emprestimos
    /// </summary>
    public class EmprestimosResumo
    {
        private string _DescricaoAviso;
        private List<Emprestimo> _Emprestimos;

        public string DescricaoAviso
        {
            get { return _DescricaoAviso; }
            set { _DescricaoAviso = value; }
        }

        public List<Emprestimo> Emprestimos
        {
            get { return _Emprestimos; }
            set { _Emprestimos = value; }
        }
    }//end EmprestimoResumo
}//end namespace Ailos.MobileBank.Models