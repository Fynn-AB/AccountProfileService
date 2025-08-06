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
```
AccountProfileService/           # Solution Root  
  
├── AccountProfileService/        
    ├── Controllers/                
    ├── DTOs/                        
    ├── Program.cs                 
    └── appsettings.json
   
├── AccountProfileService.Tests/ # Test Project  
    └── UserServiceTests.cs      # Unit tests using xUnit and Moq  
  
├── Data/
    ├── Database/                  
    ├── DbContext/                 
    ├── Entities/                
    ├── Migrations/                
    └── Services/                 
  
└── README.md                       # You're here
```  


---


## 🧪 Unit Testing

Unit tests are written with **xUnit** and **Moq**.  
They cover:

- User creation
- User update
- Password change
- User deletion
- Failure handling

---

## 📦 Tech Stack
ASP.NET Core 9  
ASP.NET Identity  
xUnit & Moq  
C# 11 / 12  
