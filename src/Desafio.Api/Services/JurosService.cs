using Desafio.Api.DTOs;

namespace Desafio.Api.Services
{
    public class JurosService : IJurosService
    {
        private const decimal PercentualJurosDiario = 0.025m;
        public CalcularJurosResponse Calcular(CalcularJurosRequest request)
        {
            if (request.Valor <= 0)
            {
                throw new ArgumentException("O valor não pode ser negativo.");
            }

            var dataCalculo = DateTime.Today;

            var diasAtraso = 0;

            if (request.DataVencimento.Date < dataCalculo)
            {
                diasAtraso = (dataCalculo.Date - request.DataVencimento.Date).Days;
            }

            var valorJuros = request.Valor * PercentualJurosDiario * diasAtraso;
            var valorAtualizado = request.Valor + valorJuros;

            return new CalcularJurosResponse
            {
                ValorOriginal = request.Valor,
                DataVencimento = request.DataVencimento,
                DataCalculo = dataCalculo,
                DiasAtraso = diasAtraso,
                PercentualDiario = PercentualJurosDiario * 100,
                ValorJuros = Math.Round(valorJuros, 2, MidpointRounding.AwayFromZero),
                ValorAtualizado = Math.Round(valorAtualizado, 2, MidpointRounding.AwayFromZero)
            };
        }
    }
}
