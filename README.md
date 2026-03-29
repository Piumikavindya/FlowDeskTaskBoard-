# FlowDesk Task Board API

## Overview

This project is a backend REST API built using **ASP.NET Core (.NET 6)** for a Task Board system as part of the FlowDesk platform. The service enables teams to create, manage, and track tasks within projects while maintaining proper relationships between users, tasks, and projects.

The API supports task lifecycle management including creation, updates, archiving, and retrieval with a structured and scalable architecture.

---

##  Features Implemented

* Task Creation with validation (title, due date)
* Task Management (update, delete, archive)
* Project Management (create, retrieve)
* User Management (create, retrieve)
* Foreign key validation (Project & User existence)
* Clean architecture with separation of concerns
* Entity Framework Core with SQL Server
* Dependency Injection using interfaces and services
* Swagger UI for API testing and discoverability

---

## Architecture & Design Decisions

* **Layered Architecture**

  * Controllers → Handle HTTP requests
  * Services → Business logic
  * Data Layer → Entity Framework Core (DbContext)

* **Use of Interfaces**

  * Improves testability and maintainability
  * Enables dependency injection

* **DTO Usage**

  * Prevents over-posting and avoids exposing internal entities

* **Database Relationships**

  * Tasks are linked to Projects and Users using foreign keys
  * Ensures data integrity

* **Validation Strategy**

  * Basic validation implemented in service/controller layer
  * Prevents invalid data (e.g., past due dates, empty titles)

---

## Technologies Used

* .NET 6 / ASP.NET Core Web API
* Entity Framework Core
* SQL Server (Express)
* Swagger (Swashbuckle)

---

## Prerequisites

Make sure you have the following installed:

* .NET 6 SDK or later
* SQL Server (Express or full version)
* SQL Server Management Studio (SSMS) *(optional but recommended)*
* Visual Studio / VS Code

---

## How to Run the Project Locally

### 1. Clone the Repository

```bash
git clone <your-repo-link>
cd FlowDesk.TaskBoard.API
```

---

### 2. Update Connection String

Open `appsettings.json` and update:

```json
"ConnectionStrings": {
  "FlowDeskDb": "Server=localhost\\SQLEXPRESS;Database=FlowDeskTaskBoardDB;User Id=sa;Password=your_password;TrustServerCertificate=True"
}
```

---

### 3. Apply Migrations & Create Database

```bash
Add-migration intial

Update-database

---

### 4. Run the Application

```bash
dotnet run
```

---

### 5. Open Swagger UI

Navigate to:

```
https://localhost:<port>/swagger
```

---

## API Endpoints

### Tasks

* `GET /api/Tasks/GetAllTasks`
* `POST /api/Tasks/CreateTask`
* `PATCH /api/Tasks/UpdateTask/{id}`
* `DELETE /api/Tasks/DeleteTask/{id}`
* `PATCH /api/Tasks/ArchiveTask/{id}`

### Projects

* `GET /api/Projects/GetAllProjects`
* `POST /api/Projects/CreateProject`

### Users

* `GET /api/Users/GetAllUsers`
* `POST /api/Users/CreateUser`

---

## Known Limitations

* No authentication/authorization implemented (JWT not added)
* No pagination or filtering for large datasets
* Limited validation 
* No unit or integration tests included
* Error handling is basic

---

## Future Improvements

Given more time, the following enhancements would be implemented:

*  JWT-based authentication and role-based authorization
*  Global exception handling middleware
*  Filtering, sorting, and pagination for task listing
*  FluentValidation for robust input validation
*  Unit and integration testing
*  Cloud deployment (Azure/AWS)
*  Logging using Serilog

---

