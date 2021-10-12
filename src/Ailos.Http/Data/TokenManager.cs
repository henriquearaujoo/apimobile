using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Http.Data
{
    public class TokenManager
    {
        private static TokenDTO _token;
        public static TokenDTO Token { get => _token; }

        public static void SetTokenWSO2(TokenDTO token)
        {
            _token = token;
            var deadTime = 20;//Int32.Parse(ConfigurationManager.AppSettings["DeadTimeAutenticacaoWSO2"]);
            var currentDate = DateTime.Now;//DateHelper.ObterDataDB();
            var totalSeconds = token.expires_in - deadTime;
            var expirationDate = currentDate.AddSeconds(totalSeconds);
            _token.ExpirationDate = expirationDate;
        }

        public static bool Expired()
        {
            if (_token == null) return true;

            var dataHoraAtual = DateTime.Now;//DateHelper.ObterDataDB();
            return _token.ExpirationDate < dataHoraAtual;
        }
    }
}
