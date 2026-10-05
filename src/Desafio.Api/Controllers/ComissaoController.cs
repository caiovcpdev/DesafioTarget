using Desafio.Api.DTOs;
using Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComissaoController : ControllerBase
    {
        private readonly IComissaoService _service;

        public ComissaoController(IComissaoService service)
        {
            _service = service;
        }
        /// <summary>
        /// Calcula a comissão das vendas agrupadas por vendedor.
        /// </summary>
        /// <remarks>
        /// Regras de comissão:
        ///
        /// # Vendas abaixo de R$ 100,00 não geram comissão.
        /// # Vendas de R$ 100,00 até R$ 499,99 geram 1% de comissão.
        /// # Vendas a partir de R$ 500,00 geram 5% de comissão.
        ///
        /// Exemplo de requisição:
        ///
        ///     POST /api/Comissoes/calcular
        ///     {
        ///         "vendas": [
        ///             {
        ///                 "vendedor": "João Silva",
        ///                 "valor": 1200.50
        ///             },
        ///             {
        ///                 "vendedor": "Maria Souza",
        ///                 "valor": 450.00
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("calcular")]
        public ActionResult<List<CalcularComissaoResponse>> Calcular(CalcularComissaoRequest request)
        {
            try
            {
                var resultado = _service.CalcularComissoes(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

