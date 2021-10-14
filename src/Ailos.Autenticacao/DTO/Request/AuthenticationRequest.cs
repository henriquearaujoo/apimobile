namespace Ailos.Autentication.DTO.Request
{
    public class AuthenticationRequest
    {
        public string Senha { get; set; }
        public string Frase { get; set; }
        public int CodigoCooperativa { get; set; }
        public int NumeroConta { get; set; }
        public int SequencialTitular { get; set; }
        public string CpfCPNJ { get; set; }
    }
}
