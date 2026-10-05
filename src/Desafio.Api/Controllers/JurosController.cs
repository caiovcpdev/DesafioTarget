using Desafio.Api.DTOs;
using Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _service;

        public JurosController(IJurosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Calcula os juros por atraso de uma dívida.
        /// </summary>
        /// <remarks>
        /// A taxa de juros utilizada é de 2,5% ao dia.
        ///
        /// Caso a data de vencimento seja hoje ou uma data futura,
        /// nenhum juros será aplicado.
        ///
        /// Exemplo de requisição:
        ///
        ///     POST /api/Juros/calcular
        ///     {
        ///         "valor": 1000.00,
        ///         "dataVencimento": "2026-10-01"
        ///     }
        ///
        /// </remarks>

        [HttpPost("calcular")]
        public ActionResult<CalcularJurosResponse> Calcular([FromBody] CalcularJurosRequest request)
        {
            try
            {
                var resultado = _service.Calcular(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
