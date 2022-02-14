# Teste Locadora
## Descrição do Projeto
Desafio para criar um serviço REST para gerenciar algumas funcionalidades básicas de uma locadora de filmes.

## Tabela de conteúdos
=================
<!--ts-->
   * [Sobre](#Sobre)
   * [Tabela de Conteudo](#tabela-de-conteudo)
   * [Features](#features)
   * [Status do Projeto](#status-do-projeto)
   * [Instalação](#instalacao)
   * [Como usar](#como-usar)
   * [Testes](#testes)
   * [Massa de dados](#massa-de-dados)
<!--te-->


## Sobre
Solução implementada em C# Asp.NET Core. Implementado o Swagger para execução dos testes de API. A solução consiste em três tipos de objetos:
### Customer
- string 'Name' (obrigatório, tamanho mínimo de 3 caracteres e máximo de 30);
- string CPF (obrigatório e tamanho fixo de 11 caracteres);

### Movie
- string Title (obrigatório, tamanho mínimo de 3 caracteres e máximo de 30);
- bool 'Avaiable' (determina se o filme está disponível para locação, sempre instanciada como 'true');

### Rental
- int 'CustomerId' (obrigatório, cliente que faz a locação);
- int MovieId (obrigatório, filme que será locado);
- DateTime ReturnDate (obrigatório, determina a data de devolução e notificação de multa)
- bool IsReturned (determina se a locação foi devolvida, sempre instanciada como 'false');
- bool Penalty (determina a locação foi devolvida com atraso, sempre instanciada como 'false');
- Ao ser feita uma locação o filme escolhido fica indisponível (Movie.Avaiable = false);
- Ao ser feita uma devolução o filme escolhido fica disponível (Movie.Avaiable = true) e se estiver em atraso haverá multa (Rental.Penalty = true);

## Features
- [x] Cadastro de cliente
- [x] Consulta de todos os clientes
- [x] Consulta de cliente por id
- [x] Consulta de todos os filmes
- [x] Cadastro de filmes
- [x] Consulta de todas as locações
- [x] Cadastrar locação
- [x] Consulta de locação por id
- [x] Fechar locação/devolução

## Status do Projeto
Disponível para avaliação técnica.

## Instalação
Clonar este repositório e a abrir a solution pelo Visual Studio (no projeto foi utilizado a versão 2019).

## Como Usar
Iniciar a aplicação através do IIS Express. Será carregada uma a página do Swagger no navegador padrão. 

## Testes
Através do Swagger é possível testar todas as APIs REST expostas.

### Customers
[GET] /v1/customers
- Retorna todos os objetos Customer em JSON.
[POST] /v1/customers
- Cria um novo objeto Customer recebendo os parâmetros 'name' e 'cpf' e retorna o objeto criado em JSON.
[GET] /v1/customers/{id}
- Recebe um id e retorna o objeto Customer correspondente em JSON.

### Movies
[GET] /v1/movies
- Retorna todos os objetos Movie em JSON.
[POST] /v1/movies
- Cria um novo objeto Movie recebendo o parâmetro 'title' e retorna o objeto criado em JSON.

### Rentals
[GET] /v1/rentals
- Retorna todos os objetos Rental em JSON.
[POST] /v1/rentals
- Cria um novo objeto Rental recebendo os parâmetros 'customerID', 'movieId' e 'returnDate' em formato JSON e retorna o objeto criado em JSON.
[GET] /v1/rentals/{id}
- Recebe um id e retorna o objeto Rental correspondente em JSON.
[PUT] /v1/rentals/closeRental/{id}
- Recebe um id de um objeto Rental e altera sua propriedade 'IsReturned' para 'true' e se houver atraso na devolução altera a propriedade 'Penalty' para 'true'.

### Massa de dados
Através do <a href="https://github.com/diegormorais/teste-locadora/blob/96da038f90542dc22fe5911512ac9f51d00849e8/Teste/Data/SeedingService.cs">SeedingService</a> foram adicionados alguns objetos que serão criados durante a inicialização e podem ser utilizados para testar as APIs.
