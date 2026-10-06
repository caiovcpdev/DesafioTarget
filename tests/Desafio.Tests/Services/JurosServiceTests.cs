using Desafio.Api.DTOs;
using Desafio.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Tests.Services
{
    public class JurosServiceTests
    {
        private readonly JurosService _service;
        public JurosServiceTests()
        {
            _service = new JurosService();
        }

        [Fact]
        public void CalcularJurosParaPagamentoEmAtraso()
        {
            var request = new CalcularJurosRequest
            {
                Valor = 1000m,
                DataVencimento = DateTime.Today.AddDays(-4)
            };

            var resultado = _service.Calcular(request);

            Assert.Equal(1000m, resultado.ValorOriginal);
            Assert.Equal(4, resultado.DiasAtraso);
            Assert.Equal(2.5m, resultado.PercentualDiario);
            Assert.Equal(100m, resultado.ValorJuros);
            Assert.Equal(1100m, resultado.ValorAtualizado);
        }

        [Fact]
        public void ZeroDeJurosParaPagamentosComVencimentoHoje()
        {
            var request = new CalcularJurosRequest
            {
                Valor = 1000m,
                DataVencimento = DateTime.Today
            };

            var resultado = _service.Calcular(request);

            Assert.Equal(0, resultado.DiasAtraso);
            Assert.Equal(0m, resultado.ValorJuros);
            Assert.Equal(1000m, resultado.ValorAtualizado);
        }

        [Fact]
        public void ZeroDeJurosParaPagamentosComVencimentoFuturo()
        {
            var request = new CalcularJurosRequest
            {
                Valor = 1000m,
                DataVencimento = DateTime.Today.AddDays(5)
            };

            var resultado = _service.Calcular(request);

            Assert.Equal(0, resultado.DiasAtraso);
            Assert.Equal(0m, resultado.ValorJuros);
            Assert.Equal(1000m, resultado.ValorAtualizado);
        }
    }
}
