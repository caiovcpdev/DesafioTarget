namespace Desafio.Api.Models
{
    public class MovimentacaoEstoque
    {
        public int Id { get; set; }

        public int CodigoProduto { get; set; }

        public TipoMovimentacao Tipo { get; set; }

        public int Quantidade { get; set; }

        public string Descricao { get; set; } = string.Empty;
    }
}
