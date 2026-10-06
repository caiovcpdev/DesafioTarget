Desafio Técnico — Target Sistemas — ASP.NET Core Web API

API desenvolvida em .NET 8 para resolução de três desafios de lógica e regras de negócio:

#Cálculo de comissão de vendas
#Controle de movimentação de estoque
#Cálculo de juros por atraso

O projeto foi desenvolvido com foco em organização, separação de responsabilidades, testabilidade e clareza do código.

Tecnologias
.NET 8
ASP.NET Core Web API
C#
xUnit
Swagger / OpenAPI

Organização

#Controllers

Responsáveis por receber as requisições HTTP e retornar as respostas da API.

#DTOs

Objetos utilizados para entrada e saída de dados dos endpoints.

#Models

Representam as entidades e estruturas utilizadas pelas regras de negócio.

#Services

Contêm as regras de negócio das três funcionalidades.

#Tests

Testes unitários utilizando xUnit para validar as regras implementadas nos Services.

1. Cálculo de Comissão

Endpoint
POST /api/Comissoes/calcular

Calcula a comissão das vendas agrupadas por vendedor.

Regras
Valor da venda	Comissão
Menor que R$ 100,00	0%
De R$ 100,00 até R$ 499,99	1%
A partir de R$ 500,00	5%

2. Movimentação de Estoque

Endpoint
POST /api/Estoque/movimentacoes

Permite realizar movimentações de entrada e saída de produtos e retorna o estoque atualizado.

Regras
A quantidade deve ser maior que zero.
A descrição da movimentação é obrigatória.
O produto deve existir.
Não é permitida saída superior ao estoque disponível.
Cada movimentação recebe um identificador único durante a execução da aplicação.

3. Cálculo de Juros

Endpoint
POST /api/Juros/calcular

Calcula os juros de uma dívida considerando a quantidade de dias em atraso.

Regra

A taxa de juros é de: 2,5% ao dia
Caso a data de vencimento seja hoje ou uma data futura, não são aplicados juros.
