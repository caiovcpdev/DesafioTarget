using Desafio.Api.Models;

namespace Desafio.Api.DTOs
{
    public class MovimentacaoEstoqueResponse
    {
        public int Id { get; set; }

        public int CodigoProduto { get; set; }

        public string Produto { get; set; } = string.Empty;

        public TipoMovimentacao Tipo { get; set; }

        public int QuantidadeMovimentada { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public int EstoqueAtual { get; set; }
    }
}
