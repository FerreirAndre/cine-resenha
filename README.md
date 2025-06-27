# 🎬 Cine.Resenha

API RESTful para registrar, gerenciar e avaliar filmes assistidos entre amigos.  
Desenvolvido com .NET 9, React e SQL Server, utilizando arquitetura Clean.

---

## 📦 Tecnologias

- ASP.NET Core 9
- React (JavaScript)
- MS SQL Server (Docker)
- Clean Architecture (Application, Domain, Persistence, API)
- Docker & Docker Compose

---

## 🚀 Como subir o projeto com Docker

```bash
docker compose up --build
faça a migrate inicial, com as flags --project apontando para o Persistence e --startup-project apontando para a Api
reinicie a api
```

Acesse:
- Frontend: `http://localhost:5173`
- Backend (API): `http://localhost:5160/api/Movies`

---

## 🌐 Endpoints da API

### 🔹 GET `/api/Movies`
Retorna todos os filmes (sem o campo `summary`).

### 🔹 GET `/api/Movies/{id}`
Retorna os detalhes completos de um filme (inclui `summary`).

### 🔹 POST `/api/Movies`
Cria um novo filme.  
**Body exemplo:**
```json
{
  "title": "Blade Runner",
  "coverLink": "https://...",
  "whoChose": "André",
  "rating": 4.5,
  "duration": 117,
  "releaseYear": 1982,
  "watched": true,
  "summary": "Descrição do filme..."
}
```

### 🔹 PUT `/api/Movies/{id}`
Atualiza os dados completos de um filme.

### 🔹 PATCH `/api/Movies/{id}/watched`
Alterna o estado de `watched` do filme (assistido / não assistido).

### 🔹 DELETE `/api/Movies/{id}`
Remove um filme pelo seu ID.

---

## 🗃️ Estrutura de Pastas

```
cine-resenha/
│
├── Cine.Resenha.Api/           # Camada de entrada da API (.NET)
├── Cine.Resenha.Application/   # Regras de negócio (Commands, Queries)
├── Cine.Resenha.Domain/        # Entidades e interfaces
├── Cine.Resenha.Persistence/   # Banco de dados e EF Core
├── Cine.Resenha.UI/            # Frontend em React
├── docker-compose.yml
└── README.md                   # Você está aqui
```

---

## 🔐 Conexão com Banco de Dados

O container MSSQL usa:

- **User:** `sa`  
- **Senha:** `Cineresenhadb`  
- **Banco:** `cine`

A string de conexão é configurada via `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=mssql;Database=cine;User Id=sa;Password=Cineresenhadb1;TrustServerCertificate=true"
}
```

---

## 🧪 Exemplos de uso

**Requisição para alternar se um filme foi assistido:**
```bash
curl -X PATCH http://localhost:5160/api/Movies/3/watched
```

**Requisição para criar um filme:**
```bash
curl -X POST http://localhost:5160/api/Movies \
  -H "Content-Type: application/json" \
  -d '{
        "title": "Bladerunner",
        "coverLink": "https://...",
        "whoChose": "Andre",
        "rating": 5.0,
        "duration": 117,
        "releaseYear": 1982,
        "watched": true,
        "summary": "Descrição do filme..."
      }'
```

