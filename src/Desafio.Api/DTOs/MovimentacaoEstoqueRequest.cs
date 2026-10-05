using Desafio.Api.Models;

namespace Desafio.Api.DTOs
{
    public class MovimentacaoEstoqueRequest
    {
        public int CodigoProduto { get; set; }

        public TipoMovimentacao Tipo { get; set; }

        public int Quantidade { get; set; }

        public string Descricao { get; set; } = string.Empty;
    }
}
