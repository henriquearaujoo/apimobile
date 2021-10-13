using System;

namespace Ailos.SOA.Common
{
    public class InteracaoGrafica
    {
        public DateTime DataAcaoUsuario
        {
            get { return DateTime.Now; }
        }

        public string Mensagem { get; set; }
    }
}