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

## Exemplos 

```json
### 🟢 GET - Listar todas as leituras (paginado)
GET {{baseUrl}}/api/v1/Reading?pageNumber=1&pageSize=10
Accept: application/json

### 🔵 POST - Criar nova leitura
POST {{baseUrl}}/api/v1/Reading
Content-Type: application/json

{
  "idReading": 1,
  "description": "Leitura inicial",
  "humor": "Feliz"
}
### 🟡 GET - Obter leitura por ID
GET {{baseUrl}}/api/v1/Reading/1
Accept: application/json

### 🟠 PUT - Atualizar leitura por ID
PUT {{baseUrl}}/api/v1/Reading/1
Content-Type: application/json

{
  "idReading": 1,
  "description": "Leitura atualizada",
  "humor": "neutro"
}

### 🔴 DELETE - Remover leitura por ID
DELETE {{baseUrl}}/api/v1/Reading/1
Accept: application/json


### PERSON

### 🟢 GET - Listar todas as pessoas
GET {{baseUrl}}/api/v1/Person
Accept: application/json

### 🔵 POST - Criar nova pessoa
POST {{baseUrl}}/api/v1/Person
Content-Type: application/json

{
  "idPerson": 1,
  "name": "Leo",
  "email": "leonardo@email.com",
  "password": "123456",
  "role": "Admin"
}

### 🟡 GET - Obter pessoa por ID
GET {{baseUrl}}/api/v1/Person/1
Accept: application/json

### 🟠 PUT - Atualizar pessoa por ID
PUT {{baseUrl}}/api/v1/Person/1
Content-Type: application/json

{
  "idPerson": 1,
  "name": "Leonardo",
  "email": "leonardo@email.com",
  "password": "654321",
  "role": "Admin"
}

### 🔴 DELETE - Remover pessoa por ID
DELETE {{baseUrl}}/api/v1/Person/1
Accept: application/json


### REVIEW

### 🟢 GET - Listar todas as reviews
GET {{baseUrl}}/api/v1/Review
Accept: application/json

### 🔵 POST - Criar nova review
POST {{baseUrl}}/api/v1/Review
Content-Type: application/json

{
  "idReview": 1,
  "idReading": 1,
  "description": "Estou feliz"
}

### 🟡 GET - Obter review por ID
GET {{baseUrl}}/api/v1/Review/1
Accept: application/json

### 🟠 PUT - Atualizar review por ID
PUT {{baseUrl}}/api/v1/Review/1
Content-Type: application/json

{
  "idReview": 1,
  "idReading": 1,
  "description": "Estou triste"
}

### 🔴 DELETE - Remover review por ID
DELETE {{baseUrl}}/api/v1/Review/1
Accept: application/json

### AUTH (LOGIN)

### 🔐 POST - Login (gerar token JWT)
POST {{baseUrl}}/api/v1/Auth/login
Content-Type: application/json

{
  "email": "leonardo@email.com",
  "password": "123456"
}
```

---

## Configuração do banco (`appsettings.json`)

Edite `appsettings.json` e configure a cadeia de conexão em `ConnectionStrings:DefaultConnection`:

---

## 🧑‍💻 Integrantes do Grupo

Guilherme Romanholi Santos - RM557462

Murilo Capristo - RM556794

Nicolas Guinante Cavalcanti - RM557844
