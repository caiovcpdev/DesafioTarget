using Desafio.Api.DTOs;
using Desafio.Api.Models;
using Desafio.Api.Services;


namespace Desafio.Tests.Services
{
    public class ComissaoServiceTests
    {
        private readonly ComissaoService _service;

        public ComissaoServiceTests()
        {
            _service = new ComissaoService();
        }
        
        [Fact]
        public void RetornarComissaoZeroParaVendasAbaixoDe100()
        {
            var request = new CalcularComissaoRequest
            {
                Vendas =
                [
                    new Venda
                    {
                        Vendedor = "Caio Vinicius",
                        Valor = 99.99m
                    }
                ]
            };

            var resultado = _service.CalcularComissoes(request);

            Assert.Single(resultado);
            Assert.Equal(0m, resultado[0].TotalComissao);
        }

        [Fact]
        public void CalcularComissaoDe1PorCentoParaVendasMenoresQue500()
        {
            var request = new CalcularComissaoRequest
            {
                Vendas =
                [
                    new Venda
                    {
                        Vendedor = "Caio Vinicius",
                        Valor = 200m
                    }
                ]
            };

            var resultado = _service.CalcularComissoes(request);

            Assert.Single(resultado);
            Assert.Equal(2m, resultado[0].TotalComissao);   
        }

        [Fact]
        public void CalcularComissaoDe5PorCentoParaVendasMaioresQue500()
        {
            var request = new CalcularComissaoRequest
            {
                Vendas =
                [
                    new Venda
                    {
                        Vendedor = "Caio Vinicius",
                        Valor = 500m
                    }
                ]
            };

            var resultado = _service.CalcularComissoes(request);

            Assert.Single(resultado);
            Assert.Equal(25m, resultado[0].TotalComissao);
        }

        [Fact]
        public void CalcularComissaoParaVariosVendedores()
        {
            var request = new CalcularComissaoRequest
            {
                Vendas =
                [
                    new Venda
                    {
                        Vendedor = "Caio Vinicius",
                        Valor = 500m
                    },
                    new Venda
                    {
                        Vendedor = "Natália Damasceno",
                        Valor = 99.99m
                    },
                    new Venda
                    {
                        Vendedor = "Bruno Vinicius",
                        Valor = 200m
                    }
                ]
            };

            var resultado = _service.CalcularComissoes(request);

            Assert.Equal(3, resultado.Count);

            var caio = resultado.First(v => v.Vendedor == "Caio Vinicius");
            var natalia = resultado.First(v => v.Vendedor == "Natália Damasceno");
            var bruno = resultado.First(v => v.Vendedor == "Bruno Vinicius");

            Assert.Equal(500m, caio.TotalVendas);
            Assert.Equal(25m, caio.TotalComissao);

            Assert.Equal(99.99m, natalia.TotalVendas);
            Assert.Equal(0m, natalia.TotalComissao);


            Assert.Equal(200m, bruno.TotalVendas);
            Assert.Equal(2m, bruno.TotalComissao);
        }
    }
}
