namespace Desafio.Api.DTOs
{
    public class CalcularComissaoResponse
    {
        public string Vendedor { get; set; } = string.Empty;

        public decimal TotalVendas { get; set; }

        public decimal TotalComissao { get; set; }
    }
}
