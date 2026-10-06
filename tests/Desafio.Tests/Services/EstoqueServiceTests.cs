using Desafio.Api.DTOs;
using Desafio.Api.Models;
using Desafio.Api.Services;

namespace Desafio.Tests.Services
{
    public class EstoqueServiceTests
    {
        private readonly EstoqueService _service;
        public EstoqueServiceTests()
        {
            _service = new EstoqueService();
        }
        [Fact]
        public void RealizarEntradaDeEstoque()
        {
            var request = new MovimentacaoEstoqueRequest
            {
                CodigoProduto = 101,
                Tipo = TipoMovimentacao.Entrada,
                Quantidade = 50,
                Descricao = "Reposição de estoque"
            };

            var resultado = _service.RealizarMovimentacao(request);

            Assert.Equal(1, resultado.Id);
            Assert.Equal(101, resultado.CodigoProduto);
            Assert.Equal("Caneta Azul", resultado.Produto);
            Assert.Equal(TipoMovimentacao.Entrada, resultado.Tipo);
            Assert.Equal(50, resultado.QuantidadeMovimentada);
            Assert.Equal("Reposição de estoque", resultado.Descricao);
            Assert.Equal(200, resultado.EstoqueAtual);
        }

        [Fact]
        public void RealizarSaidaDeEstoque()
        {
            var request = new MovimentacaoEstoqueRequest
            {
                CodigoProduto = 101,
                Tipo = TipoMovimentacao.Saida,
                Quantidade = 30,
                Descricao = "Saída para venda"
            };

            var resultado = _service.RealizarMovimentacao(request);

            Assert.Equal(1, resultado.Id);
            Assert.Equal(101, resultado.CodigoProduto);
            Assert.Equal("Caneta Azul", resultado.Produto);
            Assert.Equal(TipoMovimentacao.Saida, resultado.Tipo);
            Assert.Equal(30, resultado.QuantidadeMovimentada);
            Assert.Equal("Saída para venda", resultado.Descricao);
            Assert.Equal(120, resultado.EstoqueAtual);
        }

        [Fact]
        public void ExcecaoQuandoProdutoNaoExistir()
        {
            var request = new MovimentacaoEstoqueRequest
            {
                CodigoProduto = 999,
                Tipo = TipoMovimentacao.Entrada,
                Quantidade = 10,
                Descricao = "Reposição de estoque"
            };

            var excecao = Assert.Throws<KeyNotFoundException>(() => _service.RealizarMovimentacao(request));

            Assert.Equal("Produto não encontrado.", excecao.Message);
        }

        [Fact]
        public void ImpedirSaidaMaiorQueEstoqueDisponivel()
        {
            var request = new MovimentacaoEstoqueRequest
            {
                CodigoProduto = 101,
                Tipo = TipoMovimentacao.Saida,
                Quantidade = 151,
                Descricao = "Saída para venda"
            };

            var excecao = Assert.Throws<InvalidOperationException>(() => _service.RealizarMovimentacao(request));

            Assert.Equal("Estoque insuficiente para realizar a saída.", excecao.Message);
        }

        [Fact]
        public void ImpedirQuantidadeMenorOuIgualAZero()
        {
            var request = new MovimentacaoEstoqueRequest
            {
                CodigoProduto = 101,
                Tipo = TipoMovimentacao.Entrada,
                Quantidade = 0,
                Descricao = "Reposição"
            };

            var excecao = Assert.Throws<ArgumentException>(() => _service.RealizarMovimentacao(request));

            Assert.Equal("A quantidade deve ser maior que zero.", excecao.Message);
        }

        [Fact]
        public void ImpedirDescricaoVazia()
        {
            var request = new MovimentacaoEstoqueRequest
            {
                CodigoProduto = 101,
                Tipo = TipoMovimentacao.Entrada,
                Quantidade = 10,
                Descricao = ""
            };

            var excecao = Assert.Throws<ArgumentException>(() => _service.RealizarMovimentacao(request));

            Assert.Equal("A descrição da movimentação é obrigatória.", excecao.Message);
        }
    }
}
