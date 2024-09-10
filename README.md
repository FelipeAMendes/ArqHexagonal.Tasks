# Hexagonal App

Exemplo de aplicação utilizando a Arquitetura Hexagonal (Portas e Adaptadores) em C#. O objetivo é demonstrar uma aplicação com uma clara separação entre a lógica de negócios e as interfaces externas, permitindo uma alta flexibilidade e testabilidade.

## Arquitetura
A arquitetura do projeto é baseada no padrão Hexagonal, que divide a aplicação em diferentes camadas:

#### Camada de Domínio:

Entidades: Representa as entidades do domínio (ex: Task).<br>
Interfaces: Define contratos para os repositórios que manipulam as entidades (ex: ITaskRepository).

#### Camada de Aplicação:

Use Cases: Implementa a lógica de negócios utilizando interfaces definidas na camada de domínio (ex: ITaskService).<br>
DTOs: Objetos de transferência de dados utilizados para comunicação entre a aplicação e os adaptadores (ex: TaskDto).

#### Camada de Infraestrutura:

Data: Implementações concretas dos repositórios definidos na camada de domínio (ex: TaskRepository).

### Adaptadores:

#### CLI:
Interface de linha de comando para interagir com a aplicação.

#### API:
Interface de programação de aplicativos usando ASP.NET Core para interagir com a aplicação via HTTP.

## Configuração e Execução

### Dependências

Certifique-se de ter o .NET SDK instalado. Você pode verificar a instalação do .NET SDK com o comando:

```sh
dotnet --version
```

Configuração e Execução da CLI
Navegue para o diretório CLI:

```sh
cd ArqHexagonal.Tasks.Cli
```

Compile e execute a aplicação CLI:

```sh
dotnet run
```

### Exemplos de Uso da CLI:

Adicionar uma nova tarefa:

```sh
add "Learn Hexagonal Architecture"
```

Listar todas as tarefas:

```sh
list
```

Atualizar uma tarefa existente:

```sh
update 1 "Updated Task Description"
```

Deletar uma tarefa:

```sh
delete 1
```

Configuração e Execução da API
Navegue para o diretório API:

```sh
cd ArqHexagonal.Tasks.Api
```

Compile e execute a API:

```sh
dotnet run
```

Endpoints da API:

```sh
GET /tasks: Obtém todas as tarefas.
```

Exemplo de requisição:

```sh
curl -X GET http://localhost:5000/tasks
GET /tasks/{id}: Lista tarefas.
```

Exemplo de requisição:

```sh
curl -X GET http://localhost:5000/tasks/1
GET /tasks: Obtém tarefa por Id.
```

Exemplo de requisição:

```sh
curl -X POST http://localhost:5000/tasks -H "Content-Type: application/json" -d '{"description": "New Task"}'
POST /tasks/{id}: Adiciona uma tarefa.
```

Exemplo de requisição:

```sh
curl -X PUT http://localhost:5000/tasks/1 -H "Content-Type: application/json" -d '{"id": 1, "description": "New Name Task"}'
PUT /tasks/{id}: Atualiza uma tarefa.
```

Exemplo de requisição:

```sh
curl -X PATCH http://localhost:5000/tasks/1 -H "Content-Type: application/json"
PATCH /tasks/{id}: Completa uma tarefa.
```

Exemplo de requisição:

```sh
curl -X DELETE http://localhost:5000/tasks/1 -H "Content-Type: application/json"
DELETE /tasks/{id}: Deleta uma tarefa.
```
