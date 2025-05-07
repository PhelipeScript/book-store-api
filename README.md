# BookStoreAPI

Uma API RESTful para gerenciamento de livros, desenvolvida com ASP.NET Core. Este projeto oferece operações CRUD (Create, Read, Update, Delete) para um catálogo de livros.

## 📋 Índice

- [Requisitos](#requisitos)
- [Instalação](#instalação)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints da API](#endpoints-da-api)
- [Modelos de Dados](#modelos-de-dados)
- [Execução](#execução)

## 📦 Requisitos

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

## 🚀 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/PhelipeScript/book-store-api.git
   cd book-store-api
   ```

2. Restaure as dependências:
   ```bash
   dotnet restore
   ```

3. Crie um arquivo `books.json` na raiz do projeto para servir como banco de dados inicial (se não existir):
   ```json
   []
   ```

## 🏗️ Estrutura do Projeto

O projeto está organizado da seguinte maneira:

```
BookStoreAPI/
├── Controllers/
│   ├── BookController.cs
│   └── BookStoreAPIBASEController.cs
├── DTOs/
│   ├── CreateBookDTO.cs
│   └── UpdateBookDTO.cs
├── Entities/
│   └── Book.cs
├── Repositories/
│   ├── BookRepository.cs
│   └── Interfaces/
│       └── IBookRespository.cs
├── Properties/
│   └── launchSettings.json
├── books.json
└── Program.cs
```

## 📡 Endpoints da API

| Método | Endpoint | Descrição | Parâmetros | Retorno |
|--------|----------|-----------|------------|---------|
| GET | `/book` | Lista todos os livros | - | 200 OK com lista de livros |
| GET | `/book/{id}` | Obtém um livro pelo ID | `id` (rota) | 200 OK com livro ou 404 Not Found |
| POST | `/book/create` | Cria um novo livro | Objeto CreateBookDTO (corpo) | 201 Created com ID do livro |
| PUT | `/book/{id}` | Atualiza um livro existente | `id` (rota), Objeto UpdateBookDTO (corpo) | 200 OK ou 404 Not Found |
| DELETE | `/book/{id}` | Remove um livro | `id` (rota) | 200 OK |

### Exemplos de Requisições

#### Criar um livro (POST `/book/create`)
```json
{
  "title": "Dom Casmurro",
  "description": "Romance clássico da literatura brasileira",
  "author": "Machado de Assis",
  "genre": "Romance",
  "value": 29.90,
  "quantity": 50
}
```

#### Atualizar um livro (PUT `/book/{id}`)
```json
{
  "title": "Dom Casmurro",
  "description": "Romance clássico da literatura brasileira do século XIX",
  "author": "Machado de Assis",
  "genre": "Romance Clássico",
  "value": 34.90,
  "quantity": 45
}
```

## 📊 Modelos de Dados

### Entidade Book
```csharp
public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public float Value { get; set; }
    public int Quantity { get; set; }
}
```

### DTO de Criação
```csharp
public class CreateBookDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public float Value { get; set; }
    public int Quantity { get; set; }
}
```

### DTO de Atualização
```csharp
public class UpdateBookDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public float Value { get; set; }
    public int Quantity { get; set; }
}
```

## ⚙️ Execução

### Via linha de comando

```bash
dotnet run
```

### Via Visual Studio
1. Abra a solução no Visual Studio
2. Pressione F5 ou clique em "Iniciar Depuração"

A aplicação estará disponível em:
- HTTP: http://localhost:5289
- HTTPS: https://localhost:7247

A interface Swagger estará disponível em:
- HTTP: http://localhost:5289/swagger
- HTTPS: https://localhost:7247/swagger

## 🧪 Testando a API

Você pode testar a API usando:
- [Swagger UI](https://localhost:7247/swagger)
- [Postman](https://www.postman.com/)
- [Insomnia](https://insomnia.rest/)
- [curl](https://curl.se/)

Exemplo de teste usando curl:

```bash
# Listar todos os livros
curl -X GET http://localhost:5289/book

# Obter um livro específico
curl -X GET http://localhost:5289/book/{id}

# Criar um novo livro
curl -X POST http://localhost:5289/book/create \
  -H "Content-Type: application/json" \
  -d '{"title":"O Pequeno Príncipe","description":"Um clássico da literatura mundial","author":"Antoine de Saint-Exupéry","genre":"Fábula","value":24.90,"quantity":30}'

# Atualizar um livro
curl -X PUT http://localhost:5289/book/{id} \
  -H "Content-Type: application/json" \
  -d '{"title":"O Pequeno Príncipe","description":"Um clássico da literatura mundial para todas as idades","author":"Antoine de Saint-Exupéry","genre":"Fábula","value":27.90,"quantity":25}'

# Excluir um livro
curl -X DELETE http://localhost:5289/book/{id}
```

## 📝 Observações

- Esta API utiliza um arquivo JSON como armazenamento de dados, portanto, os dados são persistidos apenas em memória durante a execução
- Em um ambiente de produção, recomenda-se implementar um mecanismo de persistência mais robusto, como um banco de dados relacional ou NoSQL
