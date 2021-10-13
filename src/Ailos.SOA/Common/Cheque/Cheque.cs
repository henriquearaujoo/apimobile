namespace Ailos.SOA.Common.Cheque
{
    public class Cheque
    {
        public string Agencia { get; set; }
        public string AgenciaDeposito { get; set; }
        public decimal Valor { get; set; }
        public string Identificador { get; set; }
        public string Cmc7 { get; set; }
        public string Descricao { get; set; }
        public string ImagemFrente { get; set; }
        public string ImagemVerso { get; set; }
        public int Criptografado { get; set; }
        public string NrSeqDeposito { get; set; }
        public int TipoImg { get; set; }
    }
}