using Desafio.Api.DTOs;

namespace Desafio.Api.Services
{
    public class ComissaoService : IComissaoService
    {
        public List<CalcularComissaoResponse> CalcularComissoes(CalcularComissaoRequest request)
        {
            var resultado = request.Vendas
            .GroupBy(venda => venda.Vendedor)
            .Select(grupo => new CalcularComissaoResponse
            {
                Vendedor = grupo.Key,
                TotalVendas = grupo.Sum(venda => venda.Valor),
                
                TotalComissao = Math.Round(
                    grupo.Sum(venda => CalcularComissaoVenda(venda.Valor)),
                    2,
                    MidpointRounding.AwayFromZero)
                
 
                // TotalComissao = grupo.Sum(venda => CalcularComissaoVenda(venda.Valor))
            })
            .ToList();

                return resultado;
        }

        private static decimal CalcularComissaoVenda(decimal valor)
        {
            return valor switch
            {
                < 100 => 0,
                < 500 => valor * 0.01m, 
                _ => valor * 0.05m 
            };
        }
    }
 }
