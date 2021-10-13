using System;
using System.ComponentModel.DataAnnotations;

namespace Ailos.SOA.PreApprovedCard.DTO.Request
{
    public class SolicitarNovoCartaoRequest
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int CodigoEndereco { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public TipoEnderecoNovoCartao TipoEndereco { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int CodigoModalidade { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        [Range(0.0001, double.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public double Limite { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int DiaVencimento { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public int FormaPagamento { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public string NomeTitular { get; set; }

        public string NomeEmpresa { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ResultMessages))]
        public SenhasTransacao SenhasTransacao { get; set; }
    }

    public enum TipoEnderecoNovoCartao
    {
        EnderecoCooperado = 1,
        EnderecoCooperativa = 2
    }
}