using Desafio.Api.DTOs;

namespace Desafio.Api.Services
{
    public interface IEstoqueService
    {
        MovimentacaoEstoqueResponse RealizarMovimentacao(MovimentacaoEstoqueRequest request);
    }
}
