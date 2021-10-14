using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Utils
{
    public static class PasswordUtil
    {
        public static string CypherPassword(string password)
        {
            // Verifica se a senha pode ser mascarda
            if (password.Length == 8 && password.Where(c => char.IsNumber(c)).Count() > 0)
            {
                string retorno = "";

                // Mascara a senha
                for (int i = 0; i < password.Length; i++)
                {
                    retorno += password.Substring(i, 1) + password.Substring(i, 1) + ".";
                }

                // Retorna a senha mascarada
                return retorno.Remove(retorno.Length - 1);
            }

            // Retorna vazio pois não pôde mascarar a senha
            return "";
        }
    }
}
