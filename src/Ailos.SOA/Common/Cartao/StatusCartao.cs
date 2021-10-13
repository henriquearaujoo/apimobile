using System;
using System.Collections.Generic;

namespace Ailos.SOA.Common.Card
{
    public class StatusCartao
    {
        private Dictionary<int, Tuple<string, string>> StatusInfos = new Dictionary<int, Tuple<string, string>>
        {
            { 101, new Tuple<string, string>(ResultMessages.CardStatusWaitingAuthorization, ResultMessages.CardStatusWaitingAuthorizationInfo) },
            { 102, new Tuple<string, string>(ResultMessages.CardStatusApprovalPending, ResultMessages.CardStatusApprovalPendingInfo) },
            { 103, new Tuple<string, string>(ResultMessages.CardStatusAwaitingDelivery, ResultMessages.CardStatusAwaitingDeliveryInfo) },
        };

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

                if (!StatusInfos.ContainsKey(_codigo))
                    _codigo = 103;

                var infos = StatusInfos[_codigo];
                Nome = infos.Item1;
                Descricao = infos.Item2;
            }
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}