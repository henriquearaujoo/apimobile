using System;

namespace Ailos.Http.Data
{
    public class TokenManager
    {
        public static TokenDTO Token { get; private set; }

        public static void SetTokenWSO2(TokenDTO token)
        {
            Token = token;
            var deadTime = 20;//Int32.Parse(ConfigurationManager.AppSettings["DeadTimeAutenticacaoWSO2"]);
            var currentDate = DateTime.Now;//DateHelper.ObterDataDB();
            var totalSeconds = token.expires_in - deadTime;
            var expirationDate = currentDate.AddSeconds(totalSeconds);
            Token.ExpirationDate = expirationDate;
        }

        public static bool Expired()
        {
            if (Token is null) return true;

            var dataHoraAtual = DateTime.Now;//DateHelper.ObterDataDB();
            return Token.ExpirationDate < dataHoraAtual;
        }
    }
}
