using Fluxo.Caixa.Domain.Models;
using Fluxo.Caixa.Infra.Repository;
using Fluxo.Caixa.Infra.Resource;
using Fluxo.Caixa.Infra.Services;
using Microsoft.Extensions.Logging;

namespace Fluxo.Caixa.Business.Services
{
    public class LancamentosServices : ILancamentosService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ILogger<LancamentosServices> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LancamentosServices(ILancamentoRepository lancamentoRepository, IUnitOfWork unitOfWork, ILogger<LancamentosServices> logger)
        {
            _lancamentoRepository = lancamentoRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CadastroLancamentoResponse> CadastrarLancamento(Lancamentos lancamento)
        {
            try
            {
                await _lancamentoRepository.AddAsync(lancamento);
                await _unitOfWork.CompleteAsync();

                return new CadastroLancamentoResponse { Sucesso = true, Mensagem = "Lançamento cadastrado com sucesso!" };
            }
            catch (Exception ex)
            {
                _logger.LogError("[ERROR][CadastrarLancamento] Erro ao cadastrar um novo lançamento", ex.Message);
                _logger.LogError("[ERROR][CadastrarLancamento] StackTrace", ex.StackTrace);
                _logger.LogError("[ERROR][CadastrarLancamento] InnerException", ex.InnerException);

                return new CadastroLancamentoResponse
                {
                    Sucesso = false,
                    Mensagem = $"Ocorreu um erro ao salvar o lançamento: Id da Campanha {lancamento.IdLancamento} " +
                               $"Message : {ex.Message}"
                };
            }

        }

        public async Task<ConsultaLancamentoResponse> ConsultarLancamento(Lancamentos lancamento)
        {
            try
            {
                var consultaLancamento = await _lancamentoRepository.ConsultarLancamentos(lancamento);


                if (consultaLancamento.Any())
                {
                    return new ConsultaLancamentoResponse
                    {
                        Sucesso = true,
                        Mensagem = "Consulta realizada com sucesso",
                        ListaLancamentos = consultaLancamento
                    };
                }
                else
                {
                    return new ConsultaLancamentoResponse
                    {
                        Sucesso = true,
                        Mensagem = "Não foi encontrado nenhum lançamento cadastrado para os parametros enviados!",
                        ListaLancamentos = consultaLancamento
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[ERROR][ConsultarLancamento] Erro ao consultar lancamentos", ex.Message);
                _logger.LogError("[ERROR][ConsultarLancamento] StackTrace", ex.StackTrace);
                _logger.LogError("[ERROR][ConsultarLancamento] InnerException", ex.InnerException);

                return new ConsultaLancamentoResponse
                {
                    Sucesso = false,
                    Mensagem = $"Ocorreu um erro ao Consulta o lançamento: Id da Campanha {lancamento.IdLancamento} " +
                               $" Message : {ex.Message}"
                };
            }
        }

    }
}
