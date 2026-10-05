using Desafio.Api.DTOs;

namespace Desafio.Api.Services
{
    public interface IComissaoService
    {
        List<CalcularComissaoResponse> CalcularComissoes(CalcularComissaoRequest request);
    }
}
