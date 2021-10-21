using Ailos.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Autentication.ViewModel
{
    public class TokenViewModel
    {
        public string Autorizacao { get; set; }
        public string Tipo { get; set; }
        public string HashId { get; set; }
        public string Cooperativa { get; set; }
        public string NumeroConta { get; set; }
        public string TitularRepresentante { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime? UltimoAcesso { get; set; }
        public Account DadosConta { get; set; }
        public DateTime DataHoje { get; set; }
        public bool Manutencao { get; set; }
    }
}
