using Desafio.Api.DTOs;

namespace Desafio.Api.Services
{
    public interface IJurosService
    {
        CalcularJurosResponse Calcular(CalcularJurosRequest request);
    }
}
