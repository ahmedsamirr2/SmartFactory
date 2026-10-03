# Smart Factory Management System

A backend management system for monitoring and managing factory machines, production processes, and sensor data.

## Overview

Smart Factory is a .NET-based system designed to manage factory operations and provide a foundation for monitoring machine status, efficiency, temperature, maintenance, and production data.

The project is being developed as a practical enterprise-style application using clean architecture principles.

## Architecture

The solution is divided into multiple projects:

- **SmartFactory.Api** — REST API and HTTP endpoints
- **SmartFactory.Application** — Application services, DTOs, and interfaces
- **SmartFactory.Domain** — Core business entities and business rules
- **SmartFactory.Infrastructure** — Database access, repositories, and Entity Framework Core
- **SmartFactory.Tests** — Unit tests

## Current Features

- Machine management
- Machine status tracking
- Machine efficiency monitoring
- Temperature monitoring
- Maintenance tracking
- Production entities
- Sensor entities
- Repository pattern
- Entity Framework Core
- Unit testing with xUnit

## Technology Stack

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- xUnit
- Git & GitHub

## Project Structure

```text
SmartFactory/
├── SmartFactory.Api/
├── SmartFactory.Application/
├── SmartFactory.Domain/
├── SmartFactory.Infrastructure/
├── SmartFactory.Tests/
├── SmartFactory.sln
├── .gitignore
└── README.md
```

## Getting Started

Clone the repository:

```bash
git clone https://github.com/ahmedsamirr2/SmartFactory.git
```

Navigate to the project:

```bash
cd SmartFactory
```

Build the solution:

```bash
dotnet build
```

Run the tests:

```bash
dotnet test
```

## Project Status

🚧 The project is currently under development.

More features such as production management, machine monitoring, maintenance workflows, reporting, authentication, and dashboards will be added progressively.
