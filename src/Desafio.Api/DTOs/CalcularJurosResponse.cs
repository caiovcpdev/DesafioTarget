namespace Desafio.Api.DTOs
{
    public class CalcularJurosResponse
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCalculo { get; set; }
        public int DiasAtraso { get; set; }
        public decimal PercentualDiario { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorAtualizado { get; set; }
    }
}
