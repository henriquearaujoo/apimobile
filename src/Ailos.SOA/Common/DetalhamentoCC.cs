namespace Ailos.SOA.Common
{
    public class DetalhamentoCC
    {
        public DetalhamentoCC(int codigo)
        {
            origem = new Origem(codigo);
        }

        public Origem origem { get; set; }
    }

    public class Origem
    {
        public Origem(int cod)
        {
            codigo = cod;
        }

        public int codigo { get; set; }
    }
}