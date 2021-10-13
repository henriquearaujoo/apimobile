using System;
using System.ComponentModel;

namespace Ailos.SOA.Common.Cheque
{
    public class CodigoSituacao
    {
        public CodigoSituacao(int codigo)
        {
            Codigo = codigo;
        }

        //private Dictionary<StatusChequeEnum, string> StatusDescription
        //{
        //    get
        //    {
        //        return new Dictionary<StatusChequeEnum, string>
        //        {
        //            { StatusChequeEnum.EmAnalise, ResultMessages.CdcStatusInAnalysisInfo },
        //            { StatusChequeEnum.AprovadoParcial, ResultMessages.CdcStatusApprovedInfo },
        //            { StatusChequeEnum.Aprovado, ResultMessages.CdcStatusApprovedInfo },
        //            { StatusChequeEnum.Recusado, ResultMessages.CdcStatusWaitingAnalysisInfo },
        //            { StatusChequeEnum.Estornado, ResultMessages.CdcStatusWaitingAnalysisInfo },
        //            { StatusChequeEnum.Finalizado, ResultMessages.CdcStatusWaitingAnalysisInfo },
        //        };
        //    }
        //}

        private int _codigo;

        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;

                if (Enum.IsDefined(typeof(StatusChequeEnum), value))
                {
                    var enumValue = (StatusChequeEnum)value;

                    //if (StatusDescription.ContainsKey(enumValue))
                    //{
                    //    Descricao = StatusDescription[enumValue];
                    //}

                    Nome = enumValue.GetDescription();
                }
            }
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }

    public enum StatusChequeEnum
    {
        [Description("Em Análise")]
        EmAnalise = 1,

        [Description("Aprovado Parcial")]
        AprovadoParcial = 2,

        [Description("Aprovado")]
        Aprovado = 3,

        [Description("Recusado")]
        Recusado = 4,

        [Description("Estornado")]
        Estornado = 5,

        [Description("Finalizado")]
        Finalizado = 6,
    }
}