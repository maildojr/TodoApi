# ✅ Todo API Application

A robust and scalable Todo API built with ASP.NET Core 9.0 and MySQL, following Clean Architecture principles and SOLID patterns. This application provides a complete RESTful API for managing todo items with proper separation of concerns and testability.

## 🌟 Features

### 🎯 Core Functionalities
- **Create Todo** - Add new todo items with title and description
- **Read Todos** - Retrieve all todos or specific todo by ID
- **Update Todo** - Modify existing todo items (title, description, completion status)
- **Delete Todo** - Remove todo items from the system
- **Complete Todo** - Mark todos as completed/incomplete

### 🔧 Technical Features
- **RESTful API** - Clean and standardized API endpoints
- **Data Validation** - Comprehensive input validation and error handling
- **Async/Await** - Fully asynchronous operations for better performance
- **Entity Framework Core** - Modern ORM with code-first migrations
- **MySQL Integration** - Robust database support with proper connection handling
- **Swagger/OpenAPI** - Interactive API documentation
- **Dependency Injection** - Built-in IoC container for loose coupling

### Design Patterns & Principles
- **Clean Architecture** - Separation of concerns, single responsibility, and testability
- **Repository Pattern** - Encapsulation of data access logic
- **Dependency Inversion** - Loose coupling through interfaces
- **Single Responsibility** - Each class has a single responsibility

### 🛠️ Technology Stack

#### Backend Framework
- **.NET Core 9.0** - The latest version of the .NET Framework for building modern web applications
- **Entity Framework Core 9.0** - Modern ORM for working with databases
- **MySQL** - Robust database support with proper connection handling

## 🚀 Quick Start

### Requirements
- .NET Core 9.0
- MySQL 8.0 or Docker

### Instalation

1. Clone the repository
```bash
git clone https://github.com/maildojr/TodoApi.git
cd TodoApi
```

2. Configure database connection in `appsettings.json`
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TodoDb;User=root;Password=root;"
}
```

3. Run MySQL with Docker (optional)
```bash
docker run --name mysql-local -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=TodoDb -p 3306:3306 -d mysql:8.0
```

4. Apply migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. Run the application
```bash
dotnet run
```

## 📚 API Endpoints

| Method    | Endpoint | Description | Request Body |
| --------- | -------- | ----------- | ------------ |
| GET       | /api/todo | Get all todos | - |
| GET       | /api/todo/{id} | Get todo by ID | - |
| POST      | /api/todo | Create a new todo | { "title": "Todo title", "description": "Todo description" } |
| PUT       | /api/todo/{id} | Update a todo | { "title": "Updated title", "description": "Updated description" } |
| DELETE    | /api/todo/{id} | Delete a todo | - |


## 📄 License

This project is licensed under the [MIT License](https://choosealicense.com/licenses/mit/).


Built with ❤️ using ASP.NET Core, Clean Architecture, and SOLID Principles