using Ailos.Http;
using Ailos.SOA.Card.DTO.Request;
using Ailos.SOA.Card.DTO.Response;
using Ailos.SOA.Cartao.Application;
using Ailos.SOA.Common;
using Ailos.SOA.Common.Card;
using Ailos.SOA.Common.Card.Response;
using Ailos.SOA.ParametersCard.Application;
using Ailos.SOA.ParametersCard.DTO.Common;
using Ailos.SOA.ParametersCard.DTO.Request;
using Ailos.SOA.ParametersCard.DTO.Response;
using Ailos.SOA.PreApprovedCard.DTO.Common;
using Ailos.SOA.PreApprovedCard.DTO.Request;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using Ailos.SOA.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.SOA.PreApprovedCard.Application
{
    public class PreApprovedCardService : IPreApprovedCardService
    {
        private readonly IClient _client;
        private readonly IParametersCardService _parametersCardService;
        private readonly ICardService _cardService;

        public PreApprovedCardService(IClient client)
        {
            _client = new SOAClient();
        }

        //Métodos Principais
        public async Task<PropostaAndamentoResponse> PropouseProgress()
        {
            var response = new PropostaAndamentoResponse();
            var requestParams = new ObterParamPreAprovadoCartaoRequest(GetBaseModelSOARest());
            var responseParams = await _parametersCardService.GetPreApprovedParameters(requestParams);

            response.PropostaEmAndamento = responseParams.PropostaCartao != null && responseParams.PropostaCartao.IdentificadorProposta != "0";
            if (response.PropostaEmAndamento)
            {
                response.DetalhesProposta = await GetPropouseDetails(responseParams.PropostaCartao.IdentificadorProposta);
            }
            return response;
        }

        public async Task<LimitesCooperado> GetCooperativistLimit()
        {
            var newCardData = await GetNewCardData();

            var minCardLimit = newCardData.ListaTiposCartao != null ? newCardData.ListaTiposCartao.TipoCartao.Min(x => x.ConfiguracaoCredito.ValorMinimo) : 0;
            var maxCardLimit = newCardData.ListaTiposCartao != null ? newCardData.ListaTiposCartao.TipoCartao.Max(x => x.ConfiguracaoCredito.ValorMaximo) : 0;
            var maxCreditLimit = newCardData.ConfiguracaoCredito.LimiteDisponivel;

            return new LimitesCooperado
            {
                LimiteMinimo = minCardLimit,
                LimiteMaximo = maxCreditLimit > maxCardLimit ? maxCardLimit : maxCreditLimit
            };
        }

        public async Task<ModalidadesResponse> Modalities(double limit)
        {
            var newCardData = await GetNewCardData();
            return new ModalidadesResponse
            {
                Cartoes = newCardData.ListaTiposCartao.TipoCartao
                    .Where(x => x.ConfiguracaoCredito.ValorMaximo >= limit && limit >= x.ConfiguracaoCredito.ValorMinimo)
                    .Select(x => new CartaoModalidadeResponse
                    {
                        Codigo = x.Cartao.TipoModalidade.Codigo,
                        Nome = x.Cartao.TipoModalidade.Descricao,
                        Imagem = _cardService.GetCardImage(x.Cartao.TipoModalidade.Codigo),
                        DiasVencimento = x.ListaDiasVencimento.DiaVencimento.Select(y => int.Parse(y.Dia)),
                        Beneficios = x.ListaProgramasRecompensa.ProgramaRecompensa.Select(y => y.Beneficio.Beneficio).ToList(),
                        Anuidade = x.Cartao.TipoAnuidade.Codigo != 1 ? new CartaoAnuidadeResponse
                        {
                            Total = x.Cartao.ValorAnuidade,
                            ValorParcela = Math.Round(x.Cartao.ValorAnuidade / x.Cartao.QuantParcAnuidade, 2),
                            Parcelas = x.Cartao.QuantParcAnuidade
                        } : null
                    }),
                FormasPagamento = newCardData.ListaTiposLiquidacao.TipoLiquidacao.Select(x => new FormaPagamentoCartaoResponse
                {
                    Codigo = x.Codigo,
                    Descricao = x.Descricao
                }),
                NomesCartao = new NomesPlasticoCartaoResponse
                {
                    NomesTitular = newCardData.ListaNomesImpressos.NomeImpresso,
                    NomesEmpresa = newCardData.ListaEmbossadoras != null
                        ? newCardData.ListaEmbossadoras.Pessoa.Select(x => x.RazaoSocialOuNome)
                        : null
                }
            };
        }

        public async Task<EnderecoEntregaCartaoResponse> DeliveryAdresses()
        {
            var newCardData = await GetNewCardData();

            var SendCooperativist = newCardData.ListaEnderecosCooperado.TipoEnvio == 1;

            return new EnderecoEntregaCartaoResponse
            {
                EnviaCooperado = SendCooperativist,
                PrevisaoEntrega = newCardData.PropostaCartao.QtDiasEntregaPrevista,

                EnderecoPACooperado = !SendCooperativist && newCardData.ListaEnderecosCooperativa != null ? newCardData.ListaEnderecosCooperativa.Endereco
                    .Select(x => new EnderecoEntregaCartao
                    {
                        Codigo = x.PostoAtendimento.Codigo,
                        Descricao = x.PostoAtendimento.Descricao,
                        Endereco = x.PessoaContatoEndereco.TipoENomeLogradouro
                    })
                    .FirstOrDefault() : null,

                EnderecosCooperado = SendCooperativist && newCardData.ListaEnderecosCooperado.Endereco != null ? newCardData.ListaEnderecosCooperado.Endereco
                    .Where(x => x.PessoaContatoEndereco.TipoEndereco.Codigo != 90)
                    .Select(x => new EnderecoEntregaCartao
                    {
                        Codigo = x.PessoaContatoEndereco.TipoEndereco.Codigo,
                        Descricao = x.PessoaContatoEndereco.TipoEndereco.Descricao,
                        Endereco = x.PessoaContatoEndereco.TipoENomeLogradouro
                    }) : new List<EnderecoEntregaCartao>(),

                EnderecosCooperativas = SendCooperativist && newCardData.ListaEnderecosCooperativa != null ? newCardData.ListaEnderecosCooperativa.Endereco
                    .Select(x => new EnderecoEntregaCartao
                    {
                        Codigo = x.PostoAtendimento.Codigo,
                        Descricao = x.PostoAtendimento.Descricao,
                        Endereco = x.PessoaContatoEndereco.TipoENomeLogradouro
                    }) : new List<EnderecoEntregaCartao>()
            };
        }

        public async Task<MensagemRetorno> RequestPreApprovedCard(SolicitarNovoCartaoRequest request)
        {
            var newCardData = await GetNewCardData();
            var modalities = newCardData.ListaTiposCartao.TipoCartao.FirstOrDefault(x => x.Cartao.TipoModalidade.Codigo == request.CodigoModalidade);

            var preApprovedCardRequest = new SolicitarCartaoPreAprovadoRequest(GetBaseModelSOARest())
            {
                PropostaCartao = new PropostaCartaoSolicitacaoRequest
                {
                    TipoLiquidacao = new TipoRequest
                    {
                        Codigo = request.FormaPagamento
                    },
                    Emitente = new EmitenteSolicitacaoRequest(GetBaseModelSOARest())
                    {
                        IdentificadorReceitaFederal = newCardData.PropostaCartao.Emitente.IdentificadorReceitaFederal,
                        DataNascOuConstituicao = newCardData.PropostaCartao.Emitente.DataNascOuConstituicao
                    }
                },
                PessoaDigital = new PessoaDigital(GetBaseModelSOARest())
                {
                    Senha = CypherPassword(request.SenhasTransacao.Senha),
                    LetrasSeguranca = CypherLetters(request.SenhasTransacao.Letras)
                },
                Cartao = new CartaoSolicitacaoRequest
                {
                    Descricao = "INTERNACIONAL",
                    DiaVencimento = request.DiaVencimento,
                    NomeImpresso = request.NomeTitular,
                    ValorLimiteCredito = request.Limite,
                    ValorLimiteDebito = 0,
                    TipoModalidade = new TipoDescricaoRequest
                    {
                        Codigo = modalities.Cartao.TipoModalidade.Codigo,
                        Descricao = modalities.Cartao.TipoModalidade.Descricao
                    },
                    Embossadora = new EmbossadoraSolicitacaoRequest
                    {
                        RazaoSocialOuNome = request.NomeEmpresa
                    }
                },
                EnderecoCooperado = new EnderecoCooperadoSolicitacaoRequest
                {
                    TipoEnvio = newCardData.ListaEnderecosCooperado.TipoEnvio,
                    PessoaContatoEndereco = new PessoaContatoEnderecoSolicitacaoRequest
                    {
                        TipoEndereco = new TipoRequest
                        {
                            Codigo = request.TipoEndereco == TipoEnderecoNovoCartao.EnderecoCooperado ? request.CodigoEndereco : 91
                        }
                    },
                    PostoAtendimento = new TipoRequest
                    {
                        Codigo = request.TipoEndereco == TipoEnderecoNovoCartao.EnderecoCooperativa ? request.CodigoEndereco : 0
                    }
                },
                ParametrosPropostaCartao = new ParametrosPropostaCartaoRequest
                {
                    IdLimitePreAprovado = newCardData.ParametrosPropostaCartao.IdLimitePreAprovado.ToString(),
                    TipoConfiguracaoLimite = "2",
                    IndImprimePromissoria = true
                },
                PessoaDocumento = new PessoaDocumentoSolicitacaoRequest
                {
                    Identificador = newCardData.PessoaDocumento.Identificador,
                    Tipo = new TipoSigla
                    {
                        Sigla = newCardData.PessoaDocumento.Tipo.Sigla
                    }
                }
            };

            var response = _client.Post<SolicitarCartaoPreAprovadoResponse>("SolicitarCartaoPreAprovado", preApprovedCardRequest);

            return new MensagemRetorno
            {
                Mensagem = ResultMessages.CreditCardSolicitation
            };
        }

        public async Task<ListaMotivosCancelamentoOfertaResponse> GetOfferCancellationReason()
        {
            var blockListRequest = new ObterListaMotBloqueioOfertaCartaoRequest();

            var blockListResponse = await _parametersCardService.GetCardOfferBlockReasonList(blockListRequest);

            return new ListaMotivosCancelamentoOfertaResponse
            {
                Motivos = blockListResponse.ListaMotivosBloqueio.MotivoBloqueio.Select(x => new MotivosCancelamentoOferta
                {
                    Codigo = x.Codigo,
                    Descricao = x.Descricao
                }).ToList()
            };
        }

        public async Task<MensagemRetorno> CancelOffer(CancelarOfertaCartaoRequest request)
        {
            var manageCardOfferRequest = new ManterOfertaCartaoRestRequest(GetBaseModelSOARest())
            {
                OfertaCartao = new OfertaCartao
                {
                    MotivoBloqueio = new TipoRequest
                    {
                        Codigo = request.CodigoMotivo
                    }
                }
            };

            var response = await _parametersCardService.ManageCardOffer(manageCardOfferRequest);

            return new MensagemRetorno
            {
                Mensagem = ResultMessages.OfferCanceled
            };
        }

        //Métodos Complementares
        private async Task<DetalhesPropostaResponse> GetPropouseDetails(string propouseNumber)
        {
            var propouse = await GetPropouseDetailsData(propouseNumber);

            if (propouse == null)
                return null;

            var endereco = _cardService.GetPropouseAdress(propouse);
            var formaPagamento = propouse.ListaTiposLiquidacao.TipoLiquidacao.Where(x => x.IndSelecao).Select(x =>
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
                    new Row("Forma de pagamento", formaPagamento.Descricao)
                }
            });

            detalhes.Add(new AppDetails
            {
                Header = "DADOS DE ENTREGA",
                Rows = new List<Row>
                {
                    new Row("Previsão", propouse.PropostaCartao.QtDiasEntregaPrevista + " dias úteis"),
                    new Row("Endereço", endereco != null ? endereco : string.Empty)
                }
            });

            return new DetalhesPropostaResponse
            {
                NumeroProposta = propouseNumber,
                Modalidade = new DetalhesModalidadeResponse
                {
                    Nome = propouse.Cartao.TipoModalidade.Descricao,
                    Imagem = GetCardImage(propouse.Cartao.TipoModalidade.Codigo),
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
                FormaPagamento = formaPagamento,
                PrevisaoEntrega = propouse.PropostaCartao.QtDiasEntregaPrevista,
                Endereco = endereco,
                NomeTitular = propouse.Cartao.NomeImpresso,
                NomeEmpresa = propouse.Cartao.Embossadora != null ? propouse.Cartao.Embossadora.RazaoSocialOuNome : null,
                Status = new StatusCartao
                {
                    Codigo = propouse.PropostaCartao.StatusProposta.Codigo
                },
                Detalhes = detalhes
            };
        }

        private async Task<ObterDetalhePropostaResponse> GetPropouseDetailsData(string numeroProposta)
        {
            var request = new ObterDetalhePropostaRestRequest(GetBaseModelSOARest())
            {
                PropostaCartao = new PropostaCartaoDetalhesRequest(GetBaseModelSOARest())
                {
                    IdentificadorProposta = numeroProposta
                }
            };

            return await _cardService.GetPropouseDetails(request);
        }

        private async Task<ObterParametrosNovaSolicResponse> GetNewCardData()
        {
            var request = new ObterParametrosNovaSolicRequest(GetBaseModelSOARest());
            var response = await _parametersCardService.GetNewSolicitParameters(request);
            return response;
        }
    }
}