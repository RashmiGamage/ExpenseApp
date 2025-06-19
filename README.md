# 🧾 Monthly Expense Management API
A secure, modular, and scalable Web API for managing personal monthly expenses. 
Built with ASP.NET Core, CQRS, MediatR, and Entity Framework Core.

## 📦 Features

- 🔐 JWT Authentication with ASP.NET Core Identity
- ✨ Clean Architecture (CQRS + Service + Repository)
- 📄 CRUD for Monthly Expenses
- 🔍 Filter expenses by month and expence Id
- 🛠 Swagger UI for easy testing

  ---

## 🛠 Technologies

- NET Core 8
- Entity Framework Core (Code-First)
- MediatR (CQRS Pattern)
- ASP.NET Core Identity
- MSSQL Server
- Swagger
- JWT Authentication

---

## 🚀 Getting Started

1. Clone the Repository
   ```
   git clone https://github.com/RashmiGamage/ExpenseApp.git
   
   ```

2.  Configure the Database
    Update the appsettings.json with your SQL Server connection string.

3.  Run Migrations
    ```
    # Using .NET CLI
    dotnet ef migrations add InitialCreate --context AppDbContext
    dotnet ef migrations add IdentityCreate --context AppIdentityDbContext
    dotnet ef database update --context AppDbContext
    dotnet ef database update --context AppIdentityDbContext

    ```
4. Run the App
   ```
   dotnet run --project ExpenseApp.API
   
   ```
   Then open the Swagger UI: https://localhost:{port}/swagger

---
## 🧪 Testing

- Use Swagger or Postman to test endpoints.
- Register the new user. 
  ![image](https://github.com/user-attachments/assets/6c307e81-db7a-463e-88f2-5e72ec434d7c)
- Login using userName and Password(Previously registered).
- Check the response body and copy the token.
  ![image](https://github.com/user-attachments/assets/6bc44309-2d0b-4d18-b535-060b3d30c86a)
- Click the 'Authorize' button located in the top-right corner of the Swagger UI.
  ![image](https://github.com/user-attachments/assets/81feb774-f2c9-43ad-8846-f491932a455a)
- Enter the token in the value field, prefixed with the word 'Bearer' and click Authorize.
  ```
  Example:
  Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9....

  ```
- Now you can test Expense APIs.

---
## 📘 Supported API Endpoints

### 🔐 Authentication
- **POST /api/auth/register**
  
      Register a new user account.

- POST /api/auth/login
  
      Authenticate user and return a JWT token.

### 📒 Expense Management
- **POST /api/expenses**

      Create a new expense
  
      Only accessible to the authenticated user.
  
- **GET /api/expenses**

       Get all expenses for a specific month using a query parameter ?month=YYYY-MM-DD.
  
       Returns only the expenses belonging to the authenticated user.
  
- **GET /api/expenses/{id}**

       Retrieve a single expense by its ID.
  
       Only returns the expense if it belongs to the authenticated user.
  
- **PUT /api/expenses/{id}**
  
       Update an existing expense.
  
       Only allowed if the expense belongs to the authenticated user.
  
- **DELETE /api/expenses/{id}** 

      Delete an expense.
  
      Only allowed if the expense belongs to the authenticated user.





    
   
