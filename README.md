# AccountProfileService

An ASP.NET Core Web API for managing user accounts and profiles using ASP.NET Identity. Supports full CRUD operations, password management, and includes comprehensive unit testing with Moq.

## ✨ Features

- 🔐 User creation with password hashing (via ASP.NET Identity)
- 📄 User retrieval by ID or email
- 🔁 User update and password change functionality
- ❌ User deletion
- ✅ DTO-based data handling for clean separation of concerns
- 🧪 Unit tests covering success and failure cases using Moq
- 📦 RESTful API design with proper status code handling

---

## 📁 Project Structure
AccountProfileService/
├── Controllers/ # API endpoints (e.g., UserController)
├── DTOs/ # Data Transfer Objects (e.g., CreateUserDto, UpdateUserDto)
├── Services/ # Business logic and Identity integration
├── Models/ # Identity user models (e.g., UserEntity)
├── Tests/ # Unit test project using xUnit and Moq
├── Program.cs # App startup
├── appsettings.json # Configuration
└── README.md # You're here

---


Passwords are hashed automatically via Identity.
DTOs prevent over-posting and hide sensitive fields (like password hashes).
Only essential fields are exposed in GetUserDto.

## 🧪 Unit Testing

Unit tests are written with **xUnit** and **Moq**.  
They cover:

- User creation
- User update
- Password change
- User deletion
- Failure handling

📦 Tech Stack
ASP.NET Core 9
ASP.NET Identity
xUnit & Moq
C# 11 / 12
