namespace Desafio.Api.Models
{
    public class ProdutoEstoque
    {
        public int CodigoProduto { get; set; }

        public string DescricaoProduto { get; set; } = string.Empty;

        public int Estoque { get; set; }
    }
}
