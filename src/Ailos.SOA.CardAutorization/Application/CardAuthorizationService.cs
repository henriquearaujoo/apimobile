using Ailos.Http;
using Ailos.SOA.Card.DTO.Request;
using Ailos.SOA.Card.DTO.Response;
using Ailos.SOA.CardAutorization.DTO.Common;
using Ailos.SOA.CardAutorization.DTO.Request;
using Ailos.SOA.CardAutorization.DTO.Response;
using Ailos.SOA.Cartao.Application;
using Ailos.SOA.Common;
using Ailos.SOA.Common.Card;
using Ailos.SOA.Common.Card.Response;
using Ailos.SOA.Common.Response;
using Ailos.SOA.DTO.Card.Request;
using Ailos.SOA.ParametersCard.Application;
using Ailos.SOA.ParametersCard.DTO.Common;
using Ailos.SOA.ParametersCard.DTO.Request;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.SOA.CardAutorization.Application
{
    public class CardAuthorizationService : ICardAuthorizationService
    {
        private readonly IClient _client;
        private readonly ICardService _cardService;
        private readonly IParametersCardService _parametersCardService;

        public CardAuthorizationService(IClient client, ICardService cardService, IParametersCardService parametersCardService)
        {
            _client = new SOAClient();
            _cardService = cardService;
            _parametersCardService = parametersCardService;
        }

        public async Task<AutorizacaoListaResponse> GetAuthorizePendencies()
        {
            var cardPendencyListRequest = new ObterListaPendenciasCartaoRequest(GetBaseModelSOARest());
            var cardPendencyListResponse = await _cardService.GetCardPendencyList(cardPendencyListRequest);

            return new AutorizacaoListaResponse
            {
                Resultado = cardPendencyListResponse.ListaOperacoesPendencia != null ? cardPendencyListResponse.ListaOperacoesPendencia.OperacaoPendencia.Select(x => new DetalhesListaAutorizacao
                {
                    NumeroProposta = x.PropostaCartao.IdentificadorProposta,
                    Modalidade = x.Cartao.TipoModalidade.Descricao,
                    LimiteContratado = x.Cartao.ValorLimiteCredito,
                    DataContratacao = x.PropostaCartao.DataCriacao,
                    Status = new StatusCartao
                    {
                        Codigo = x.OperacaoDigital.Status.Codigo.HasValue ? (int)x.OperacaoDigital.Status.Codigo : 0
                    }
                }).ToList() : new List<DetalhesListaAutorizacao>()
            };
        }

        public async Task<DetalhesPropostaResponse> AuthorizePendancyDetails(string propouseNumber)
        {
            var detalhes = await GetPropouseDetails(propouseNumber);

            if (detalhes == null)
                ReturnBadRequest(ResultMessages.ProposalNotFound);

            return detalhes;
        }

        public async Task<EditarCartaoResponse> AuthorizePendancyEdit(string propouseNumber)
        {
            var proposta = await GetPropouseDetailsData(propouseNumber);

            if (proposta == null)
                ReturnBadRequest(ResultMessages.ProposalNotFound);

            return new EditarCartaoResponse
            {
                DiasVencimento = proposta.ListaDiasVencimento.DiaVencimento.Select(x => int.Parse(x.Dia)).ToList(),
                FormasPagamento = proposta.ListaTiposLiquidacao.TipoLiquidacao.Select(x => new FormaPagamentoCartaoResponse
                {
                    Codigo = x.Codigo,
                    Descricao = x.Descricao
                }),
                NomesCartao = new NomesPlasticoCartaoResponse
                {
                    NomesTitular = proposta.ListaNomesImpressos.NomeImpresso,
                    NomesEmpresa = proposta.ListaEmbossadoras != null
                        ? proposta.ListaEmbossadoras.Pessoa.Select(x => x.RazaoSocialOuNome)
                        : null
                }
            };
        }

        public async Task<MensagemRetorno> PropouseStatusApprove(AprovarCartaoRequest request)
        {
            ValidateAccessInformationWebSpeed(request.SenhasTransacao.Senha, request.SenhasTransacao.Letras);

            var effectiveRequest = new EfetivarSituacaoPropostaRequest(GetBaseModelSOARest())
            {
                PropostaCartao = new PropostaCartaoRequest(GetBaseModelSOARest())
                {
                    IdentificadorProposta = request.NumeroProposta,
                    TipoInteracao = "APROVA",
                    TipoLiquidacao = new TipoRequest
                    {
                        Codigo = request.FormaPagamento
                    }
                },
                Cartao = new CartaoRequest
                {
                    DiaVencimento = request.DiaVencimento,
                    NomeImpresso = request.NomeTitular,
                    Embossadora = new EmbossadoraRequest
                    {
                        RazaoSocialOuNome = request.NomeEmpresa
                    }
                }
            };

            var response = await PropouseStatusEffective(effectiveRequest);

            return new MensagemRetorno
            {
                Mensagem = ResultMessages.CreditCardApproved
            };
        }

        public async Task<MensagemRetorno> PropouseStatusCancel(CancelarCartaoRequest request)
        {
            var effectiveRequest = new EfetivarSituacaoPropostaRequest(GetBaseModelSOARest())
            {
                PropostaCartao = new PropostaCartaoRequest(GetBaseModelSOARest())
                {
                    IdentificadorProposta = request.NumeroProposta,
                    TipoInteracao = "REJEITA",
                    TipoLiquidacao = new TipoRequest
                    {
                        Codigo = request.FormaPagamento
                    },
                    MotivoResultado = new TipoRequest
                    {
                        Codigo = request.CodigoMotivo
                    }
                },
                Cartao = new CartaoRequest
                {
                    DiaVencimento = request.DiaVencimento,
                    NomeImpresso = request.NomeTitular,
                    Embossadora = new EmbossadoraRequest
                    {
                        RazaoSocialOuNome = request.NomeEmpresa
                    }
                }
            };

            var response = await PropouseStatusEffective(effectiveRequest);

            return new MensagemRetorno
            {
                Mensagem = ResultMessages.CreditCardCanceled
            };
        }

        public async Task<ResponseControlResponse> PropouseStatusEffective(EfetivarSituacaoPropostaRequest request)
        {
            return await _client.Post<ResponseControlResponse>("EfetivarSituacaoProposta", request);
        }

        public async Task<MotivosCancelamentoCartaoResponse> CardCancellationReasons()
        {
            var requestSOA = new ObterListaMotivoNegCartaoRequest();

            var response = await _parametersCardService.GetDeniedCardReasonList(requestSOA);
            return new MotivosCancelamentoCartaoResponse
            {
                Motivos = response.ListaMotivosResultado.MotivoResultado.Select(x => new Motivo
                {
                    Codigo = x.Codigo,
                    Descricao = x.Descricao
                }).ToList()
            };
        }

        //Metodos Complementares
        private async Task<DetalhesPropostaResponse> GetPropouseDetails(string propouseNumber)
        {
            var propouse = await GetPropouseDetailsData(propouseNumber);

            if (propouse == null)
                return null;

            var address = _cardService.GetPropouseAdress(propouse);
            var paymentForm = propouse.ListaTiposLiquidacao.TipoLiquidacao.Where(x => x.IndSelecao).Select(x =>
                    new FormaPagamentoCartaoResponse
                    {
                        Codigo = x.Codigo,
                        Descricao = x.Descricao
                    }).FirstOrDefault();

            var detalhes = new List<AppDetails>();

            var dadosCartao = new AppDetails
            {
                Header = "DADOS DO CARTÃO"
            };

            dadosCartao.AddRow("Modalidade", propouse.Cartao.TipoModalidade.Descricao);

            if (GetBaseModelSOARest().TipoPessoa == "2" && propouse.Cartao.Embossadora != null)
                dadosCartao.AddRow("Nome da empresa", propouse.Cartao.Embossadora.RazaoSocialOuNome);

            dadosCartao.AddRow("Nome no cartão", propouse.Cartao.NomeImpresso);
            dadosCartao.AddRow("Data de contratação", propouse.PropostaCartao.DataCriacao.ToString("dd/MM/yyy"));
            dadosCartao.AddRow("Limite contratado (R$)", propouse.Cartao.ValorLimiteCredito.FormatBRL());

            detalhes.Add(dadosCartao);

            detalhes.Add(new AppDetails
            {
                Header = "DADOS DA FATURA",
                Rows = new List<Row>
                {
                    new Row("Dia do vencimento da fatura", propouse.Cartao.DiaVencimento.ToString().PadLeft(2, '0')),
                    new Row("Forma de pagamento", paymentForm.Descricao)
                }
            });

            detalhes.Add(new AppDetails
            {
                Header = "DADOS DE ENTREGA",
                Rows = new List<Row>
                {
                    new Row("Previsão", propouse.PropostaCartao.QtDiasEntregaPrevista + " dias úteis"),
                    new Row("Endereço", address != null ? address : string.Empty)
                }
            });

            return new DetalhesPropostaResponse
            {
                NumeroProposta = propouseNumber,
                Modalidade = new DetalhesModalidadeResponse
                {
                    Nome = propouse.Cartao.TipoModalidade.Descricao,
                    Imagem = _cardService.GetCardImage(propouse.Cartao.TipoModalidade.Codigo),
                    Beneficios = propouse.ListaProgramasRecompensa.ProgramaRecompensa.Select(x => x.Beneficio.Beneficio),
                    Anuidade = propouse.Cartao.TipoAnuidade.Codigo != 1 ? new CartaoAnuidadeResponse
                    {
                        Total = propouse.Cartao.ValorAnuidade,
                        ValorParcela = Math.Round(propouse.Cartao.ValorAnuidade / propouse.Cartao.QuantParcAnuidade, 2),
                        Parcelas = propouse.Cartao.QuantParcAnuidade
                    } : null
                },
                DataContratacao = propouse.PropostaCartao.DataCriacao,
                LimiteContratado = propouse.Cartao.ValorLimiteCredito,
                DiaVencimento = propouse.Cartao.DiaVencimento,
                FormaPagamento = paymentForm,
                PrevisaoEntrega = propouse.PropostaCartao.QtDiasEntregaPrevista,
                Endereco = address,
                NomeTitular = propouse.Cartao.NomeImpresso,
                NomeEmpresa = propouse.Cartao.Embossadora != null ? propouse.Cartao.Embossadora.RazaoSocialOuNome : null,
                Status = new StatusCartao
                {
                    Codigo = propouse.PropostaCartao.StatusProposta.Codigo
                },
                Detalhes = detalhes
            };
        }

        private async Task<ObterDetalhePropostaResponse> GetPropouseDetailsData(string propouseNumber)
        {
            var request = new ObterDetalhePropostaRestRequest(GetBaseModelSOARest())
            {
                PropostaCartao = new PropostaCartaoDetalhesRequest(GetBaseModelSOARest())
                {
                    IdentificadorProposta = propouseNumber
                }
            };

            return await _cardService.GetPropouseDetails(request);
        }
    }
}