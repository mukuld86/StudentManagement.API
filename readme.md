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
- Swagger / OpenAPI
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
- Async/Await

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
```

## 🔄 Request Flow

The backend follows a layered architecture:

```text
HTTP Request
     ↓
Controller
     ↓
Service
     ↓
Repository
     ↓
Entity Framework Core
     ↓
SQL Server
```

## 🗄️ Database

The application uses SQL Server with Entity Framework Core.

Database:

```text
StudentManagementDb
```

The `Students` table contains:

```text
Id
RegistrationNumber
Name
Course
Age
Email
```

`Id` is the SQL Server identity column and is generated automatically.

`RegistrationNumber` is a meaningful student registration number entered by the application/user.

## 🔐 Authentication

The API uses JWT-based authentication.

Login flow:

```text
User Login
    ↓
AuthController
    ↓
AuthService
    ↓
Validate User
    ↓
Generate JWT
    ↓
Return Token
```

The JWT contains claims including:

- User ID
- User Role
- JWT ID

Protected endpoints require a valid JWT.

## 👥 Authorization

The application implements role-based authorization.

| Feature | Admin | Teacher | Student |
|:---|:---:|:---:|:---:|
| View Students | ✅ | ✅ | ✅ |
| Search | ✅ | ✅ | ✅ |
| Add Student | ✅ | ❌ | ❌ |
| Edit Student | ✅ | ✅ | ❌ |
| Delete Student | ✅ | ❌ | ❌ |

Authorization is enforced at the API level using ASP.NET Core's `[Authorize]` attribute.

## 📡 API Endpoints

### Authentication

```http
POST /api/auth/login
```

Used to authenticate a user and receive a JWT.

### Students

Get all students:

```http
GET /api/students
```

Get a student by registration number:

```http
GET /api/students/{registrationNumber}
```

Create a student:

```http
POST /api/students
```

Update a student:

```http
PUT /api/students/{registrationNumber}
```

Delete a student:

```http
DELETE /api/students/{registrationNumber}
```

## 🔒 Endpoint Authorization

| Endpoint | Authorization |
|:---|:---|
| `GET /api/students` | Authenticated users |
| `GET /api/students/{registrationNumber}` | Authenticated users |
| `POST /api/students` | Admin |
| `PUT /api/students/{registrationNumber}` | Admin / Teacher |
| `DELETE /api/students/{registrationNumber}` | Admin |

## 🌐 CORS

The API is configured to allow requests from the React development server:

```text
http://localhost:5173
```

This allows the React frontend to communicate with the ASP.NET Core API during development.

## ⚙️ Configuration

Update `appsettings.json` with your SQL Server connection string and JWT configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=StudentManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "YOUR_SECRET_KEY",
    "Issuer": "StudentManagementAPI",
    "Audience": "StudentManagementAPI"
  }
}
```

> Do not commit real passwords, secret keys, or production connection strings to GitHub.

## ▶️ Running the Project

### 1. Clone the repository

```bash
git clone YOUR_BACKEND_REPOSITORY_URL
```

### 2. Open the project

Open the solution in Visual Studio.

### 3. Configure SQL Server

Make sure SQL Server is running and update the connection string in:

```text
appsettings.json
```

### 4. Apply EF Core migrations

```bash
dotnet ef database update
```

### 5. Run the API

```bash
dotnet run
```

Or run the project directly from Visual Studio.

Swagger will be available at:

```text
https://localhost:7009/swagger
```

## 🔗 Frontend

The React frontend is maintained in a separate repository.

```text
React Frontend
      ↓
Axios
      ↓
ASP.NET Core Web API
      ↓
Entity Framework Core
      ↓
SQL Server
```

## 📚 Learning Outcomes

This project was built as part of a .NET Full Stack Development learning path and provided practical experience with:

- ASP.NET Core Web API
- REST APIs
- Entity Framework Core
- SQL Server
- LINQ
- Repository Pattern
- Service Layer
- Async/Await
- JWT Authentication
- Role-Based Authorization
- CORS
- Swagger API testing

## 👨‍💻 Author

**Mukul Deshwal**

Computer Science & Engineering
