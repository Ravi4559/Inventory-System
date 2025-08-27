## Inventory-System
I have created an Inventory System which allows the person to manage it own inventory. 
In this project I have created a Inventory System for a Coffee Machine Seller


### Description of Inventory-System
A simple Inventory Management System built using RESTful API,  ASP.NET Core and Entity Framework Core, using in Visual Studio 2022 
demonstrating product CRUD (C – Create ,R – Read,U – Update,D – Delete) operations.By the use of this 
Inventory system we can created a record, read it ,Update it and Delete it.

### Features
- Add Product – Name, Description, Price, StockQuantity, Category. 
- Get All Products – Optionally filter by Category and sort by Price. 
- Get Product by ID – Fetch a single product. 
- Update Product – Modify product details like price or stock. 
- Delete Product – Delete the Product data
- Search  -by product name or description
- Low Stock Alert

### Tech Stack
- RESTful API
-  ASP.NET Core Web API
-  SQL Server
-  Swagger API


###  API Endpoints

<img width="1865" height="783" alt="image" src="https://github.com/user-attachments/assets/7278572a-7c93-4036-b834-b292b6d26b8e" />


### Stepup Steps

#### Step 1 🔹 Step 1: Prerequisites

Make sure you have installed:

  - .NET 8 SDK or .NET 7 SDK (check your project’s target framework in InventoryPortal.csproj)
  - SQL Server / LocalDB (your connection string uses (localdb)\MSSQLLocalDB)
  -  Visual Studio 2022 or VS Code with C# extension
  - Swagger  ( for API testing)

####  Step 2: Open the Project

Open InventoryPortal.sln in Visual Studio. OR run in terminal:

#### Step 3: Configure Database

Your appsettings.json contains:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ProductsDb;Trusted_connection=true;TrustServerCertificate=true"
}

This means it will connect to a SQL Server LocalDB instance named ProductsDb

##### Open Package Manager Console (Visual Studio → Tools → NuGet Package Manager → Package Manager Console).

- Run EF Core migrations:
- Add-Migration InitialCreate
- Update-Database
This will create your ProductsDb database and tables from your ApplicationDbContext.

#### Step 4: Run the Project

Run with:

dotnet run Or press F5 in Visual Studio.

The API will start at:

Swagger UI: https://localhost:5001/swagger (Development environment auto-enables Swagger)

API endpoints: https://localhost:5001/api/...

#### Step 5: Test API

- Open Swagger at https://localhost:5001/swagger
- Test endpoints (e.g., Products CRUD if you created controllers).
- Alternatively, use Postman to call APIs.




