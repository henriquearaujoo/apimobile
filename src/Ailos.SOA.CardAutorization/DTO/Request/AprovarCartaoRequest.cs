using Ailos.SOA.CardAutorization.DTO.Common;
using System.ComponentModel.DataAnnotations;

namespace Ailos.SOA.CardAutorization.DTO.Request
{
    public class AprovarCartaoRequest
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public string NumeroProposta { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int DiaVencimento { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int FormaPagamento { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public string NomeTitular { get; set; }

        public string NomeEmpresa { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public SenhasTransacao SenhasTransacao { get; set; }
    }
}