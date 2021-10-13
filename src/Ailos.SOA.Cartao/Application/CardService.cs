using Ailos.Http;
using Ailos.SOA.Card.DTO.Request;
using Ailos.SOA.Card.DTO.Response;
using Ailos.SOA.Common.Cartao.Response;
using Ailos.SOA.DTO.Card.Request;
using Ailos.SOA.DTO.Card.Response;
using Ailos.SOA.ParametersCard.Application;
using Ailos.SOA.ParametersCard.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.SOA.Cartao.Application
{
    public class CardService : ICardService
    {
        private readonly IClient _client;
        private readonly IParametersCardService _parametersCardService;

        public CardService(IClient client, IParametersCardService parametersCardService)
        {
            _client = new SOAClient();
            _parametersCardService = parametersCardService;
        }

        //Metodos Principais
        public async Task<TermoAdesaoCartaoResponse> GetAdhesionTerm(ObterTermoAdesaoRequest request)
        {
            var requestSOA = new ObterTermoAdesaoRequest(GetBaseModelSOARest());

            var response = await _client.Post<ObterTermoAdesaoResponse>("ObterInformTermoAdesao", requestSOA);
            return new TermoAdesaoCartaoResponse
            {
                TermoAdesao = response.Termo
            };
        }

        public async Task<ObterDetalhePropostaResponse> GetPropouseDetails(ObterDetalhePropostaRestRequest request)
        {
            return await _client.Post<ObterDetalhePropostaResponse>("ObterDetalheProposta", request);
        }

        public async Task<ObterListaPendenciasCartaoResponse> GetCardPendencyList(ObterListaPendenciasCartaoRequest request)
        {
            return await _client.Post<ObterListaPendenciasCartaoResponse>("ObterListaPendenciasCartao", request);
        }

        public async Task<PermissoesCartaoResponse> TakeMenuPermissions()
        {
            var requestParams = new ObterParamPreAprovadoCartaoRequest(GetBaseModelSOARest());
            var resultParams = await _parametersCardService.GetPreApprovedParameters(requestParams);

            var requestPendencyList = new ObterListaPendenciasCartaoRequest(GetBaseModelSOARest());
            var resultPendencyList = await this.GetCardPendencyList(requestPendencyList);

            var possuiProposta = resultParams.PropostaCartao != null && resultParams.PropostaCartao.IdentificadorProposta != "0";

            var possuiAutorizacaoPendente = true;

            if (resultPendencyList.ListaOperacoesPendencia == null || resultPendencyList.ListaOperacoesPendencia.OperacaoPendencia.Count <= 0)
            {
                possuiAutorizacaoPendente = false;
            }
            else
            {
                possuiAutorizacaoPendente = !resultPendencyList.ListaOperacoesPendencia.OperacaoPendencia.Any(x =>
                {
                    if (!x.OperacaoDigital.Status.Codigo.HasValue)
                        return true;

                    if (string.IsNullOrEmpty(x.PropostaCartao.IdentificadorProposta))
                        return true;

                    return false;
                });
            }
            return new PermissoesCartaoResponse
            {
                CartaoPreAprovado = (resultParams.ConfiguracaoCredito != null && resultParams.ConfiguracaoCredito.LimiteDisponivel > 0) || possuiProposta,
                AutorizacaoCartao = possuiAutorizacaoPendente
            };
        }

        //Metodos Complementares
        public string GetPropouseAdress(ObterDetalhePropostaResponse proposta)
        {
            if (proposta.ListaEnderecosCooperativa != null && proposta.ListaEnderecosCooperativa.Endereco != null)
                return proposta.ListaEnderecosCooperativa.Endereco.FirstOrDefault().PessoaContatoEndereco.TipoENomeLogradouro;

            if (proposta.ListaEnderecosCooperado != null && proposta.ListaEnderecosCooperado.Endereco != null)
                return proposta.ListaEnderecosCooperado.Endereco.FirstOrDefault().PessoaContatoEndereco.TipoENomeLogradouro;

            return null;
        }

        public Uri GetCardImage(int codigoCartao)
        {
            var imagensPath = new Dictionary<int, string>
            {
                { 11, "essencial.png" },
                { 12, "classico.png" },
                { 13, "gold.png" },
                { 14, "platinum.png" },
                { 15, "empresas.png" },
                { 16, "Puro-debito.png" },
                { 17, "Empresas-debito.png" },
                { 18, "CartaoNow.PNG" }
            };

            var cdnPath = AppSettings["CdnPath"];

            if (imagensPath.ContainsKey(codigoCartao))
                return new Uri(cdnPath + "imagens/cartoes/" + imagensPath[codigoCartao]);

            return null;
        }
    }
}