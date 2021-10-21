using Ailos.Autentication.DTO.Response;
using Ailos.Autentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Autentication.Application
{
    public class AutenticacaoWebSpeedService //: IAuthenticationService
    {
        //public Task<Token> AuthenticateAsync(AuthenticationViewModel request)
        //{
        //    string senha = request.SenhasAutenticacao.Senha;
        //    string frase = request.SenhasAutenticacao.Frase.ToUpper();
        //    string fraseNova = null;
        //    string fraseRepetida = null;
        //    bool primeiroAcesso = false;

        //    if (!string.IsNullOrEmpty(request.SenhasAutenticacao.FraseRepetida))
        //    {
        //        primeiroAcesso = true;
        //        frase = (string)null;
        //        fraseNova = request.SenhasAutenticacao.Frase.ToUpper();
        //        fraseRepetida = request.SenhasAutenticacao.FraseRepetida.ToUpper();
        //    }

        //    request.SenhasAutenticacao.Senha = string.Empty;
        //    request.SenhasAutenticacao.Frase = string.Empty;
        //    request.SenhasAutenticacao.FraseRepetida = string.Empty;

        //    if (request.Dispositivo.TipoAutenticacao == 0) request.Dispositivo.TipoAutenticacao = (int)TipoAutenticacao.Senha;

        //    Token result = null;

        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
