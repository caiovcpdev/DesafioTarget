using Desafio.Api.DTOs;
using Desafio.Api.Models;

namespace Desafio.Api.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly List<ProdutoEstoque> _produtos =
        [
             new ProdutoEstoque
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            },
            new ProdutoEstoque
            {
                CodigoProduto = 102,
                DescricaoProduto = "Caderno Universitário",
                Estoque = 75
            },
            new ProdutoEstoque
            {
                CodigoProduto = 103,
                DescricaoProduto = "Borracha Branca",
                Estoque = 200
            },
            new ProdutoEstoque
            {
                CodigoProduto = 104,
                DescricaoProduto = "Lápis Preto HB",
                Estoque = 320
            },
            new ProdutoEstoque
            {
                CodigoProduto = 105,
                DescricaoProduto = "Marcador de Texto Amarelo",
                Estoque = 90
            }
        ];

        private int _proximoId = 1;
        public MovimentacaoEstoqueResponse RealizarMovimentacao(MovimentacaoEstoqueRequest request)
        {
            if(request.Quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            }

            if (string.IsNullOrEmpty(request.Descricao))
            {
                throw new ArgumentException("A descrição da movimentação é obrigatória.");
            }

            var produto = _produtos.FirstOrDefault(produto => produto.CodigoProduto == request.CodigoProduto);

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }   

            if (request.Tipo == TipoMovimentacao.Saida && request.Quantidade > produto.Estoque)
            {
                throw new InvalidOperationException("Estoque insuficiente para realizar a saída.");
            }

            if (request.Tipo == TipoMovimentacao.Entrada)
            {
                produto.Estoque += request.Quantidade;
            }
            else
            {
                produto.Estoque -= request.Quantidade;  
            }

            var movimentacao = new MovimentacaoEstoque 
            { 
                Id = _proximoId++,
                CodigoProduto = produto.CodigoProduto,
                Tipo = request.Tipo,
                Quantidade = request.Quantidade,
                Descricao = request.Descricao
            };

            return new MovimentacaoEstoqueResponse
            {
                Id = movimentacao.Id,
                CodigoProduto = produto.CodigoProduto,
                Produto = produto.DescricaoProduto,
                Tipo = movimentacao.Tipo,
                QuantidadeMovimentada = movimentacao.Quantidade,
                Descricao = movimentacao.Descricao,
                EstoqueAtual = produto.Estoque
            };
        }
    }
}
