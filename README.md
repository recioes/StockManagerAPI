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
  <img alt="design" height="400px" src= "https://private-user-images.githubusercontent.com/118849369/306836999-0190b7e0-f5c7-4e8f-9d5f-97dc8effa1f9.jpg?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDg1NzA3NzEsIm5iZiI6MTcwODU3MDQ3MSwicGF0aCI6Ii8xMTg4NDkzNjkvMzA2ODM2OTk5LTAxOTBiN2UwLWY1YzctNGU4Zi05ZDVmLTk3ZGM4ZWZmYTFmOS5qcGc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwMjIyJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDIyMlQwMjU0MzFaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1mN2M0MTVlZTU1Zjg2NTNmMThlYjU0OWFlNmY3MWVkMDBjM2IyMmFmNWNmOTJlMThlNzZkYmQzMTNlNDk4NDdiJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.wmlvPxdyp91RhDMDdU73dlI992yafyL1uobPC7K0INw">
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
