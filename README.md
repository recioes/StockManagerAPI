<h1 align="center"> StockManager API 📦 </h1>

<p align="center">
O projeto "StockManager API" é uma aplicação C# desenvolvida para gerenciar o estoque de uma loja. Esta API foi construída aplicando conceitos de POO, princípios SOLID, e práticas de Código Limpo, com documentação facilitada pelo Swagger. O objetivo principal é fornecer uma API RESTful para o CRUD (Criar, Ler, Atualizar e Deletar) de itens de estoque. 
  A API foi desenvolvida em resposta a um desafio que encontrei no GitHub (com várias adaptações): https://github.com/myfreecomm/desafio-backend-dotnet
</p>
<p align="center">
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-estrutura-do-projeto">Estrutura do Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-configurações">Configurações</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-camada-de-repositories">Camada de Repositories</a>
</p>

<br>

<p align="center">
  <img alt="design" height="600px" src= "https://source.unsplash.com/random/900%C3%97700/?inventory">
</p>

## 🚀 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- C#
- ASP.NET Core
- MySQL
- Dapper
- xUnit
- Git e GitHub

## 💻 Estrutura do Projeto

A solução é dividida em quatro projetos principais:

- **Stock API**: Contém as controllers, program, DI e um Middleware.
- **StockAPI.Infra**: Engloba a infraestrutura do projeto, como repositórios.
- **StockAPI.Core**: O núcleo do projeto, incluindo models, DTOs, services e interfaces.
- **StockAPI.Tests**: Destinado aos testes unitários utilizando XUnit (serão feitos em uma segunda versão do projeto).

## ⚙️ Configurações

- **String de Conexão**: Armazenada no arquivo `appsettings.json` e protegida no arquivo `.env`.
- **Injeção de Dependências**: Configurada na pasta `DI/ServiceExtension` para manter o código organizado.

## 📚 Camada de Repositories

Desenvolvi classes de repositório para operações CRUD:

- **`ProductRepository`**
- **`StockItemRepository`**
- **`StoreRepository`**

Cada uma implementa interfaces dedicadas e utiliza `IDbConnection` para gerenciar a conexão com o banco de dados.
