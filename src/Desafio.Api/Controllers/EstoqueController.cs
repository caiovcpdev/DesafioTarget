using Desafio.Api.DTOs;
using Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;
        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        /// <summary>
        /// Realiza uma movimentação de entrada ou saída de estoque.
        /// </summary>
        /// <remarks>
        /// A movimentação deve informar:
        ///
        /// # Código do produto.
        /// # Tipo da movimentação (Entrada ou Saida).
        /// # Quantidade.
        /// # Descrição da movimentação.
        ///
        /// Exemplo de requisição:
        ///
        ///     POST /api/Estoque/movimentacoes
        ///     {
        ///         "codigoProduto": 101,
        ///         "tipo": "Entrada",
        ///         "quantidade": 50,
        ///         "descricao": "Reposição de estoque"
        ///     }
        ///
        /// Observação: O estoque não pode ficar negativo.
        /// </remarks>

        [HttpPost("movimentacao")]
        public ActionResult<MovimentacaoEstoqueResponse> RealizarMovimentacao([FromBody] MovimentacaoEstoqueRequest request)
        {
            try
            {
                var resultado = _service.RealizarMovimentacao(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
