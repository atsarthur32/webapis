using AutoMapper;
using Fluxo.Caixa.Infra.Resource;
using Fluxo.Caixa.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fluxo.RelatorioDiario.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class FluxoRelatorioDiarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRelatorioDiarioService _relatorioDiarioService;

        public FluxoRelatorioDiarioController(
            IRelatorioDiarioService relatorioDiarioService,
            IMapper mapper)
        {
            _relatorioDiarioService = relatorioDiarioService;
            _mapper = mapper;
        }


        /// <summary>
        /// Este método ira consultar a tabela TB_RELATORIO_DIARIO para consultas realizadas em data anterior a data atual,
        /// Caso contrario ira consultar a tabela TB_LANCAMENTOS para consultar lançamentos do dia.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ConsultaRelatorioDiario")]
        [ProducesResponseType(typeof(ConsultaRelatorioDiarioResponse), 200)]
        [ProducesResponseType(typeof(ErroResponse), 400)]
        public async Task<IActionResult> ConsultaRelatorioDiario([FromQuery] ConsultaRelatorioDiarioRequest request)
        {
            var consultaRelatorio = _mapper.Map<ConsultaRelatorioDiarioRequest, Caixa.Domain.Models.RelatorioDiario>(request);

            var response = await _relatorioDiarioService.ConsultaRelatorioDiario(consultaRelatorio);

            if (!response.Sucesso)
                return BadRequest(new ErroResponse(response.Mensagem));

            return Ok(response);
        }

    }
}