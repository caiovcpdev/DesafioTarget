using Desafio.Api.Models;

namespace Desafio.Api.DTOs
{
    public class CalcularComissaoRequest
    {
        public List<Venda> Vendas { get; set; } = new();
    }
}
