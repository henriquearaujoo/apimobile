using System.ComponentModel.DataAnnotations;

namespace Ailos.SOA.CardAutorization.DTO.Request
{
    public class CancelarCartaoRequest
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public string NumeroProposta { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int CodigoMotivo { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int DiaVencimento { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int FormaPagamento { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public string NomeTitular { get; set; }

        public string NomeEmpresa { get; set; }
    }
}