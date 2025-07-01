# Contact Manager - ASP.NET Core Razor Pages

Aplicação web desenvolvida em ASP.NET Core com Razor Pages para gerenciamento de contatos. Projeto completo com autenticação, validações, exclusão lógica (soft delete), e testes automatizados de validação.

---

## 🔧 Tecnologias Utilizadas

- ASP.NET Core 6.0
- Razor Pages
- Entity Framework Core
- MariaDB 10.6
- Docker + Docker Compose
- xUnit (testes automatizados)
- Bootstrap 5

---

## 🚀 Funcionalidades

- ✅ Listagem de contatos
- ✅ Cadastro com validações
- ✅ Edição de contatos existentes
- ✅ Visualização de detalhes
- ✅ Exclusão lógica (soft delete)
- ✅ Autenticação por cookies com login fixo
- ✅ Testes automatizados de validação do modelo

---

## 🔐 Autenticação

- Apenas a tela de listagem é pública.
- As páginas de **criação**, **edição**, **exclusão** e **detalhes** exigem login.
- **Credenciais fixas:**
  - Usuário: `admin`
  - Senha: `12345`

---

## 🐳 Testar Localmente com Docker

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Docker](https://www.docker.com/)

### 1. Suba o banco de dados com Docker Localmente para teste

Na raiz do projeto, entre na pasta MariaDB_local, execute:

```bash
docker compose up -d
