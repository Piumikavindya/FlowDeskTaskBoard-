# FlowDeskTaskBoard API

## Overview

**FlowDeskTaskBoard** is a RESTful API for managing tasks and projects. It provides a comprehensive task management system where users can create, organize, update, and track tasks across different projects with priority levels and status tracking.

### Key Features
- ✅ Full CRUD operations for tasks
- ✅ Task status management (ToDo, InProgress, Done)
- ✅ Priority-based task organization (Low, Medium, High)
- ✅ Task archiving capability
- ✅ Project and user assignment support
- ✅ RESTful API with Swagger documentation
- ✅ Database persistence with SQL Server and Entity Framework Core

### Tech Stack
- **Backend**: ASP.NET Core 8.0
- **ORM**: Entity Framework Core 9.0.14
- **Database**: SQL Server
- **API Documentation**: Swagger/OpenAPI
- **Architecture**: Service-oriented with dependency injection

---

## Prerequisites

Before running the project, ensure you have the following installed:

1. **.NET 8 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
2. **SQL Server** - [Download Express Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (free and sufficient for development)
3. **SQL Server Management Studio (SSMS)** - [Optional, for database management](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
4. **Git** - [Download here](https://git-scm.com/)
5. **Visual Studio Code** or **Visual Studio** - [Download IDE](https://visualstudio.microsoft.com/)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourrepo/FlowDeskTaskBoard.git
cd FlowDeskTaskBoard
```

### 2. Configure the Database Connection

Open `appsettings.json` and update the SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "FlowDeskDb": "Server=YOUR_SERVER;Database=FlowDeskDb;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

**Connection String Options:**
- **Windows Authentication**: `"Server=.;Database=FlowDeskDb;Trusted_Connection=true;TrustServerCertificate=true;"`
- **SQL Authentication**: `"Server=localhost;Database=FlowDeskDb;User Id=sa;Password=YourPassword;TrustServerCertificate=true;"`
- **LocalDB** (if using Visual Studio): `"Server=(localdb)\\mssqllocaldb;Database=FlowDeskDb;Trusted_Connection=true;"`

### 3. Restore Dependencies

Navigate to the project directory and restore NuGet packages:

```bash
cd TaskBoard.API
dotnet restore
```

### 4. Apply Database Migrations

Run the Entity Framework migrations to create the database schema:

```bash
dotnet ef database update
```

If migrations haven't been applied yet, you can create them manually:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Run the Application

Start the development server:

```bash
dotnet run
```

The API will be available at: `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP)

### 6. Access Swagger UI

Open your browser and navigate to:
```
https://localhost:5001/swagger
```

You can test all API endpoints directly from the Swagger UI.

---

## API Endpoints

### Task Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/tasks/GetAllTasks` | Retrieve all tasks |
| `POST` | `/api/tasks/CreateTask` | Create a new task |
| `PUT` | `/api/tasks/UpdateTask/{id}` | Update an existing task |
| `DELETE` | `/api/tasks/DeleteTask/{id}` | Delete a task |
| `PATCH` | `/api/tasks/ArchiveTask/{id}` | Archive a task |

### Request/Response Examples

**Create Task (POST)**
```json
{
  "title": "Implement Authentication",
  "description": "Add JWT-based authentication to API",
  "status": "InProgress",
  "priority": "High",
  "dueDate": "2026-04-15",
  "projectId": 1,
  "assignedUserId": 1
}
```

**Task Response**
```json
{
  "id": 1,
  "title": "Implement Authentication",
  "description": "Add JWT-based authentication to API",
  "status": "InProgress",
  "priority": "High",
  "dueDate": "2026-04-15T00:00:00",
  "isArchived": false,
  "projectId": 1,
  "project": null,
  "assignedUserId": 1,
  "assignedUser": null
}
```

---

## Project Structure

```
TaskBoard.API/
├── Controllers/           # API endpoint handlers
│   ├── TasksController.cs
│   └── WeatherForecastController.cs
├── Models/               # Data models
│   ├── TaskItem.cs
│   ├── Project.cs
│   ├── User.cs
│   ├── TaskCreate.cs
│   └── GetAllTasks.cs
├── Services/             # Business logic layer
│   └── TaskService.cs
├── Interfaces/           # Service contracts
│   └── ITaskService.cs
├── Data/                 # Database context (Entity Framework)
│   └── AppDbContext.cs
├── Migrations/           # Database schema versions
├── Properties/           # Project configuration
├── appsettings.json      # Configuration file
├── Program.cs            # Application startup
└── TaskBoard.API.csproj  # Project file
```

---

## Development Notes

### Database Migrations

If you modify the models, create and apply a new migration:

```bash
dotnet ef migrations add YourMigrationName
dotnet ef database update
```

### Service Layer

The application follows a service-oriented architecture:
- **ITaskService**: Interface defining task operations
- **TaskService**: Implementation of task business logic
- **AppDbContext**: Entity Framework context for database operations

---

## Known Limitations & Future Improvements

### Current Limitations

1. **No Authentication/Authorization**
   - The API currently has no JWT or identity management
   - Any client can access all endpoints

2. **Limited Error Handling**
   - Error responses could be more descriptive
   - No global exception middleware for consistent error formatting

3. **No Input Validation**
   - Request models lack data annotations for validation
   - No business logic validation (e.g., empty titles, invalid dates)

4. **Incomplete Entity Relationships**
   - Project and User navigation properties not fully populated
   - No cascade delete or referential integrity constraints

5. **No Logging**
   - No structured logging or debugging capabilities
   - Makes troubleshooting production issues difficult

6. **Missing Pagination**
   - GetAllTasks returns all records without pagination
   - Could cause performance issues with large datasets

### Improvements Given More Time

1. **Security**
   - Implement JWT-based authentication
   - Add authorization roles (Admin, Manager, User)
   - Input sanitization and CORS policies

2. **Data Validation**
   - Add FluentValidation for comprehensive request validation
   - Server-side business logic validation
   - Better HTTP status codes (400 for validation, 409 for conflicts)

3. **Advanced Features**
   - Implement pagination, filtering, and sorting
   - Add task comments and activity tracking
   - Implement task dependencies
   - Add user notifications/reminders

4. **Performance & Scalability**
   - Add database indexing on frequently queried columns
   - Implement caching (Redis) for frequently accessed data
   - Add query optimization and N+1 query prevention

5. **Code Quality**
   - Add unit and integration tests (xUnit/NUnit)
   - Implement repository pattern for data access
   - Add API versioning for backward compatibility
   - API rate limiting

6. **Infrastructure**
   - Docker containerization
   - CI/CD pipeline setup (GitHub Actions, Azure DevOps)
   - Deployment to Azure/AWS
   - Database backup and recovery strategies

7. **Documentation**
   - Comprehensive API documentation with examples
   - Architecture decision records (ADRs)
   - Deployment guides
   - Contributing guidelines

---

## Troubleshooting

### Issue: Connection String Error
**Solution**: Verify SQL Server is running and your connection string is correct. Use SSMS to test the connection.

### Issue: Migration Fails
**Solution**: Clear the database and reapply migrations:
```bash
dotnet ef database drop --force
dotnet ef database update
```

### Issue: Port Already in Use
**Solution**: Change the port in `launchSettings.json` or use:
```bash
dotnet run --urls "https://localhost:5002"
```

---

## Contact & Support

For questions or issues, please open an issue on the repository or contact the development team.

**Last Updated**: March 29, 2026  
**Framework**: .NET 8  
**Status**: Work in Progress
