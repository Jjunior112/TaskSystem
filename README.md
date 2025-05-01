# 📝 Task API - ASP.NET Core

Este projeto é uma **API REST** para gerenciamento de tarefas, construída com **ASP.NET Core**, utilizando os padrões **Repository Pattern** e **Unit of Work**, com persistência em **SQL Server** por meio do **Entity Framework Core**.

## 🔧 Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Repository Pattern
- Unit of Work

## 📚 Funcionalidades

A API permite:

- 🔍 **Visualizar todas as tarefas**
- 📄 **Visualizar uma tarefa por ID**
- ➕ **Criar uma nova tarefa**
- ✏️ **Atualizar uma tarefa existente**
- ❌ **Deletar uma tarefa**
- ⚠️ **Verificar duplicidade de tarefas** antes da criação com base no nome da tarefa

## 🛠️ Padrões Implementados

- **Repository Pattern**: abstração das operações de dados para promover um código mais limpo e desacoplado.
- **Unit of Work**: garante que um conjunto de operações relacionadas sejam executadas de forma atômica.

## 📦 Endpoints da API

| Método | Rota              | Descrição                        |
|--------|-------------------|----------------------------------|
| GET    | `/api/tasks`      | Lista todas as tarefas           |
| GET    | `/api/tasks/{id}` | Retorna uma tarefa específica    |
| POST   | `/api/tasks`      | Cria uma nova tarefa             |
| PUT    | `/api/tasks/{id}` | Atualiza uma tarefa existente    |
| DELETE | `/api/tasks/{id}` | Deleta uma tarefa                |

### 🔁 Verificação de Duplicidade

Ao criar uma nova tarefa, o sistema verifica se já existe outra tarefa com o mesmo título (ou critério definido). Se houver, a API retorna um erro informando a duplicação.

## ▶️ Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/task-api.git
cd task-api
```

Atualize a string de conexão em appsettings.json.


Execute as migrações:

   ```bash
   dotnet ef database update
      
```

Inicie a aplicação:

```bash
dotnet run

```

✅ Exemplo de JSON para criação de tarefa

```json
{
  "taskName": "string",
  "status": "Pending"
}
```
✅ Exemplo de JSON de retorno da criação de tarefa

```json
{
    "id": "a093c060-c508-45b0-b17a-b4901e46c2bb",
    "taskName": "Teste",
    "createdAt": "2025-05-01T18:48:13.8408589",
    "status": "Completed",
    "completedAt": "2025-05-01T18:53:31.0335634"
  }
