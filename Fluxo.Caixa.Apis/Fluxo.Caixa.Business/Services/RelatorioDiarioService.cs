using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Domain.Response;
using Fluxo.Caixa.Infra.Repository;
using Fluxo.Caixa.Infra.Resource;
using Fluxo.Caixa.Infra.Services;
using Microsoft.Extensions.Logging;

namespace Fluxo.Caixa.Business.Services
{
    public class RelatorioDiarioService : IRelatorioDiarioService
    {
        private readonly IRelatorioDiarioRepository _relatorioDiarioRepository;
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;

        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILogger<LancamentosServices> _logger;

        public RelatorioDiarioService(IRelatorioDiarioRepository relatorioDiarioRepository,
                                      ILancamentoRepository lancamentoRepository,
                                      ITipoPagamentoRepository tipoPagamentoRepository,
                                      ILogger<LancamentosServices> logger)
        {
            _relatorioDiarioRepository = relatorioDiarioRepository;
            _lancamentoRepository = lancamentoRepository;
            _tipoPagamentoRepository = tipoPagamentoRepository;
            _logger = logger;
        }

        /// <summary>
        /// Tabela de Relatorio diario depende de um Job ou DTS para ser populada com o consolidado do dia, caso nao existir é verificado os lançamentos
        /// </summary>
        /// <param name="relatorioDiario"></param>
        /// <returns></returns>
        public async Task<ConsultaRelatorioDiarioResponse> ConsultaRelatorioDiario(RelatorioDiario relatorioDiario)
        {
            try
            {
                var consultaRelatorioDiario = await _relatorioDiarioRepository.ConsultaRelatorioDiario(relatorioDiario);

                if (consultaRelatorioDiario.Any())
                {
                    return new ConsultaRelatorioDiarioResponse
                    {
                        Sucesso = true,
                        Mensagem = "ConsultaRelatorioDiario realizada com sucesso",
                        ListaRelatorioDiario = consultaRelatorioDiario
                    };
                }
                else
                {
                    var consultaLancamentos = VerificarLancamentosDiarioRelatorio(relatorioDiario);

                    if (consultaLancamentos.ListaRelatorioDiario.Any())
                    {
                        return consultaLancamentos;
                    }

                    return new ConsultaRelatorioDiarioResponse
                    {
                        Sucesso = true,
                        Mensagem = "Não foi encontrado nenhum relatório para os parametros enviados!",
                        ListaRelatorioDiario = consultaRelatorioDiario
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("[ERROR][ConsultaRelatorioDiario] Erro ao consultar relatorio diario ", ex.Message);
                _logger.LogError("[ERROR][ConsultaRelatorioDiario] StackTrace", ex.StackTrace);
                _logger.LogError("[ERROR][ConsultaRelatorioDiario] InnerException", ex.InnerException);

                return new ConsultaRelatorioDiarioResponse
                {
                    Sucesso = false,
                    Mensagem = $"Ocorreu um erro ao Consulta o lançamento: " +
                               $" Message : {ex.Message}"
                };
            }
        }
        
        /// <summary>
        ///  Método que verifica os lançamentos do dia caso o relatório diario nao exista na tabela consolidada.
        /// </summary>
        /// <param name="relatorioDiario"></param>
        /// <returns></returns>
        private ConsultaRelatorioDiarioResponse VerificarLancamentosDiarioRelatorio(RelatorioDiario relatorioDiario)
        {
            try
            {
                var consultaRelatorioDiario = new List<RelatorioDiarioResponse>();

                var consultaLancamentos = _lancamentoRepository.ConsultarLancamentos(
                                            new Lancamentos
                                            {
                                                IdEmpresa = relatorioDiario.IdEmpresa,
                                                IdTipoPagamento = relatorioDiario.IdTipoPagamento,
                                                DataLancamento = relatorioDiario.DataFechamento
                                            }).Result;

                if (consultaLancamentos.Any())
                {
                    var consultaTiposPagamentoDisponiveis = _tipoPagamentoRepository.ConsultarTodosTiposPagamento();

                    if (consultaTiposPagamentoDisponiveis.Any())
                    {
                        foreach (var item in consultaTiposPagamentoDisponiveis)
                        {
                            if (consultaLancamentos.Any(_ => _.TipoPagamento == item.Descricao))
                            {
                                consultaRelatorioDiario.Add(new RelatorioDiarioResponse
                                {
                                    DataFechamento = relatorioDiario.DataFechamento,
                                    NomeEmpresa = consultaLancamentos[0].Empresa,
                                    TipoPagamento = item.Descricao,
                                    ValorTotal = consultaLancamentos.Where(_ => _.TipoPagamento == item.Descricao).Sum(_ => _.Valor)
                                });
                            }
                        }
                    }
                    return new ConsultaRelatorioDiarioResponse
                    {
                        Sucesso = true,
                        Mensagem = "ConsultaRelatorioDiario realizada com sucesso",
                        ListaRelatorioDiario = consultaRelatorioDiario
                    };
                }
                return new ConsultaRelatorioDiarioResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError("[ERROR][VerificarLancamentosDiarioRelatorio] Erro ao consultar lançamentos relatorio diario ", ex.Message);
                _logger.LogError("[ERROR][VerificarLancamentosDiarioRelatorio] StackTrace", ex.StackTrace);
                _logger.LogError("[ERROR][VerificarLancamentosDiarioRelatorio] InnerException", ex.InnerException);

                return new ConsultaRelatorioDiarioResponse
                {
                    Sucesso = false,
                    Mensagem = $"Ocorreu um erro ao Consulta o lançamento para relatorio diario: " +
                               $" Message : {ex.Message}"
                };
            }
        }
    }
}
