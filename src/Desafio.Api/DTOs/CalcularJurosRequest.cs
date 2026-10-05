namespace Desafio.Api.DTOs
{
    public class CalcularJurosRequest
    {
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
