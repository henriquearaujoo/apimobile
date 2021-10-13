using System;
using System.ComponentModel.DataAnnotations;

namespace Ailos.SOA.PreApprovedCard.DTO.Request
{
    public class CancelarOfertaCartaoRequest
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int CodigoMotivo { get; set; }
    }
}