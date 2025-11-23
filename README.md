# EMMA — API REST em .NET

API REST desenvolvida em ASP.NET Core para gerenciar leituras, pessoas e reviews. Projeto organizado em camadas: Model, Business, Data e API, com rotas versionadas em `/api/v1/...`, autenticação JWT e suporte a Swagger para exploração dos endpoints.

---

## Visão geral

- Nome do projeto: EMMA  
- Propósito: CRUD de entidades `Reading`, `Person` e `Review`, com paginação, links HATEOAS e autenticação JWT.  
- Arquitetura: separação entre Model, Business, Data e API para melhor testabilidade e manutenção.

---

## Arquitetura e justificativa

- Separação de responsabilidades entre camadas.
- Lógica de negócio isolada na camada Business.
- Acesso a dados via Entity Framework Core.
- Endpoints expostos pela camada API para consumo por clientes (mobile/web) e testes via Swagger.
- Facilita testes unitários e integração com serviços externos (ex.: IoT, se necessário).

---

## Rotas principais (exemplo)

- `ReadingController`
  - GET `/api/v1/Reading?pageNumber={n}&pageSize={m}` — lista paginada (retorna links HATEOAS: self, first, prev, next, last)  
  - GET `/api/v1/Reading/{id}` — obter leitura por id  
  - POST `/api/v1/Reading` — criar leitura  
  - PUT `/api/v1/Reading/{id}` — atualizar leitura  
  - DELETE `/api/v1/Reading/{id}` — remover leitura

- `PersonController`
  - GET `/api/v1/Person`
  - GET `/api/v1/Person/{id}`
  - POST `/api/v1/Person`
  - PUT `/api/v1/Person/{id}`
  - DELETE `/api/v1/Person/{id}`

- `ReviewController`
  - GET `/api/v1/Review`
  - GET `/api/v1/Review/{id}`
  - POST `/api/v1/Review`
  - PUT `/api/v1/Review/{id}`
  - DELETE `/api/v1/Review/{id}`

- `AuthController`
  - POST `/api/v1/Auth/login` — gera JWT

---

## Tecnologias

- .NET 9 / C# 13  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- Swagger (Swashbuckle)  
- Visual Studio 2022+  
- Docker (opcional)

---

## Como executar (CLI)

1. git clone https://github.com/NicolasGCADS/Project-EMMA-CSharp.git  
2. dotnet restore  
3. dotnet build  
4. dotnet run --project "EMMA Project/EMMA Project.csproj"  
5. Abrir Swagger: `http://localhost:5232/swagger/index.html`
6. Deploy : http://74.163.194.87:5232/swagger/index.html

---

## Configuração do banco (`appsettings.json`)

Edite `appsettings.json` e configure a cadeia de conexão em `ConnectionStrings:DefaultConnection`:

---

## 🧑‍💻 Integrantes do Grupo

Guilherme Romanholi Santos - RM557462

Murilo Capristo - RM556794

Nicolas Guinante Cavalcanti - RM557844
