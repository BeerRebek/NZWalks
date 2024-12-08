# NZWalks API

NZWalks is an ASP.NET Core API project that provides CRUD operations for managing regions, walks, and walk difficulties in New Zealand. The project follows a clean architecture and implements authentication and authorization.

## Features

- **Region Management**: Add, edit, delete, and retrieve information about regions.
- **Walk Management**: Perform CRUD operations on walking trails.
- **Difficulty Management**: Define and manage the difficulty levels of walking trails.
- **User Authentication**: Secure the API using Identity JWT for user authentication and management.

## Technologies Used

- **.NET Core**
- **C#**
- **SQL Server**
- **Entity Framework Core**
- **Clean Architecture**
- **AutoMapper**
- **API Versioning**
- **Serilog**
- **JWT Bearer**

## Project Structure

- **NZWalks.API**: Contains API controllers for handling HTTP requests and responses.
- **NZWalks.DataAccess**: Includes repositories implementing the Repository Pattern for data access operations.
- **NZWalks.Model**: Contains domain models and DTOs (Data Transfer Objects) for data exchange.
- **NZWalks.Service**: Implements business logic and interacts with the Data Access layer.

## API Endpoints

### Region Endpoints

- `GET /api/regions`: Retrieve all regions.
- `GET /api/regions/{id}`: Retrieve a region by ID.
- `POST /api/regions`: Create a new region.
- `PUT /api/regions/{id}`: Update a region by ID.
- `DELETE /api/regions/{id}`: Delete a region by ID.

### Walk Endpoints

- `GET /api/walks`: Retrieve all walks.
- `GET /api/walks/{id}`: Retrieve a walk by ID.
- `POST /api/walks`: Create a new walk.
- `PUT /api/walks/{id}`: Update a walk by ID.
- `DELETE /api/walks/{id}`: Delete a walk by ID.

### Difficulty Endpoints

- `GET /api/difficulties`: Retrieve all difficulties.
- `GET /api/difficulties/{id}`: Retrieve a difficulty by ID.
- `POST /api/difficulties`: Create a new difficulty.
- `PUT /api/difficulties/{id}`: Update a difficulty by ID.
- `DELETE /api/difficulties/{id}`: Delete a difficulty by ID.

## Authentication

The API uses JWT Bearer tokens for authentication. Users must authenticate to access protected endpoints.

## Getting Started

### Prerequisites

- .NET Core SDK
- Visual Studio or Visual Studio Code
- SQL Server

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/BeerRebek/NZWalks.git
