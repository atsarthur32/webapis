using AutoMapper;
using Fluxo.Caixa.Infra.Resource;
using Fluxo.Caixa.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fluxo.Lancamentos.Caixa.Api.Controllers
{

    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class FluxoLancamentosController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILancamentosService _lancamentoService;

        public FluxoLancamentosController(
            ILancamentosService lancamentoService,
            IMapper mapper)
        {
            _lancamentoService = lancamentoService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/CadastroLancamento")]
        [ProducesResponseType(typeof(CadastroLancamentoResponse), 200)]
        [ProducesResponseType(typeof(ErroResponse), 400)]
        public async Task<IActionResult> CadastroLancamento([FromBody] CadastroLancamentoRequest request)
        {
            var cadastrolanemento = _mapper.Map<CadastroLancamentoRequest, Fluxo.Caixa.Domain.Models.Lancamentos>(request);           

            var response = await _lancamentoService.CadastrarLancamento(cadastrolanemento);

            if (!response.Sucesso)
                return BadRequest(new ErroResponse(response.Mensagem));

            return Ok(response);
        }

        [HttpGet]
        [Route("api/ConsultarLancamento")]
        [ProducesResponseType(typeof(ConsultaLancamentoResponse), 200)]
        [ProducesResponseType(typeof(ErroResponse), 400)]
        public async Task<IActionResult> ConsultarLancamento([FromQuery] ConsultaLancamentoRequest request)
        {
            var cadastrolanemento = _mapper.Map<ConsultaLancamentoRequest, Fluxo.Caixa.Domain.Models.Lancamentos>(request);

            var response = await _lancamentoService.ConsultarLancamento(cadastrolanemento);

            if (!response.Sucesso)
                return BadRequest(new ErroResponse(response.Mensagem));

            return Ok(response);
        }
    }
}