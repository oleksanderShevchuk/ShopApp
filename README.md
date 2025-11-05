# ShopApp

A simple **.NET Core Web API** for managing store data, implemented using **Clean Architecture**.

## Features

- Retrieve clients whose birthday is on a specific date
- Retrieve recent customers within the last N days
- Retrieve purchased product categories for a specific client with quantities
- Clean Architecture: Domain, Application, Infrastructure, API layers
- Dependency Injection, Repository + Unit of Work patterns
- Custom DTO mappers
- Unit tests with xUnit and Moq
- Swagger API documentation

## Technologies

- .NET 9
- C#
- Entity Framework Core
- MS SQL Server
- xUnit / Moq
- Swagger (OpenAPI)

## Architecture

```

Presentation
└── ShopApp.API
Application
└── ShopApp.Application
Domain
└── ShopApp.Domain
Infrastructure
└── ShopApp.Infrastructure
Tests
└── ShopApp.Tests

````

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/oleksanderShevchuk/ShopApp.git
cd ShopApp
````

### 2. Configure Database

Update connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=local;Database=ShopDb;Trusted_Connection=True;"
}
```

### 3. Apply Migrations & Seed Data

```bash
dotnet ef database update --project src/ShopApp.Infrastructure --startup-project src/ShopApp.API
```

Optionally, run the SQL script in `scripts/SeedData.sql` to insert sample data.

### 4. Run the API

```bash
cd ShopApp.API
dotnet run
```

The API will be available at `https://localhost:5001` (Swagger at `https://localhost:5001/swagger`)

### 5.Running with Docker

1. Build and run containers:

```bash
docker-compose up --build

### 6. API Endpoints

* `GET /api/shop/birthdays?date=YYYY-MM-DD` - List of clients with birthday on the specified date
* `GET /api/shop/recent?days=N` - List of clients who made purchases in the last N days
* `GET /api/shop/categories/{clientId}` - List of product categories purchased by the client with quantities

### 7. Running Tests

```bash
cd tests/ShopApp.UnitTests
dotnet test
```

## License

MIT
