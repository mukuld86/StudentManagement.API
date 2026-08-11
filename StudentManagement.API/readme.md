# Student Management System - Backend

ASP.NET Core Web API backend for a full-stack Student Management System.

The application provides student CRUD operations, registration-number based search, JWT authentication, role-based authorization, Entity Framework Core integration, and SQL Server database connectivity.

## 🚀 Features

- Student CRUD operations
- Search student by Registration Number
- Repository Pattern
- Service Layer
- Entity Framework Core
- SQL Server
- JWT Authentication
- Role-Based Authorization
- Async API operations
- CORS configuration
- Swagger API testing
- Role-based access for Admin, Teacher, and Student

## 🛠️ Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT
- Swagger / OpenAPI
- LINQ
- Repository Pattern

## 🏗️ Project Architecture

```text
StudentManagement.API
│
├── Controllers
│   ├── StudentsController.cs
│   └── AuthController.cs
│
├── Services
│   ├── StudentService.cs
│   └── AuthService.cs
│
├── Repositories
│   └── StudentRepository.cs
│
├── Models
│   ├── Student.cs
│   ├── User.cs
│   └── SignInRequest.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Program.cs
└── appsettings.json