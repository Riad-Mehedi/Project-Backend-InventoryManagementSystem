📦 Inventory Management System (IMS) - .NET Core Web API

📖 Overview
This project is a **RESTful Web API** built with **ASP.NET Core Web API** to manage inventory operations.
Currently, it supports **4 CRUD modules**:

* **Category**
* **Supplier**
* **Product**
* **StockTransaction**


🚀 Features Implemented
* **Category Management** – Add, view, update, delete categories
* **Supplier Management** – Manage supplier details
* **Product Management** – CRUD operations for inventory items
* **Stock Transactions** – Track stock in/out operations



🔜 **Future Planned Features**:
* Authentication & Role Management
* Reports & Analytics
* Stock Alerts
* Search & Filtering


📂 API Endpoints
```
### 🔹 Category

| Method | Endpoint           | Description         |
| ------ | ------------------ | ------------------- |
| GET    | /api/category      | Get all categories  |
| GET    | /api/category/{id} | Get category by ID  |
| POST   | /api/category      | Create new category |
| PUT    | /api/category/{id} | Update category     |
| DELETE | /api/category/{id} | Delete category     |

### 🔹 Supplier

| Method | Endpoint           | Description         |
| ------ | ------------------ | ------------------- |
| GET    | /api/supplier      | Get all suppliers   |
| GET    | /api/supplier/{id} | Get supplier by ID  |
| POST   | /api/supplier      | Create new supplier |
| PUT    | /api/supplier/{id} | Update supplier     |
| DELETE | /api/supplier/{id} | Delete supplier     |

### 🔹 Product

| Method | Endpoint          | Description        |
| ------ | ----------------- | ------------------ |
| GET    | /api/product      | Get all products   |
| GET    | /api/product/{id} | Get product by ID  |
| POST   | /api/product      | Create new product |
| PUT    | /api/product/{id} | Update product     |
| DELETE | /api/product/{id} | Delete product     |

### 🔹 StockTransaction

| Method | Endpoint                   | Description                |
| ------ | -------------------------- | -------------------------- |
| GET    | /api/stocktransaction      | Get all stock transactions |
| GET    | /api/stocktransaction/{id} | Get transaction by ID      |
| POST   | /api/stocktransaction      | Record new transaction     |
| PUT    | /api/stocktransaction/{id} | Update transaction         |
| DELETE | /api/stocktransaction/{id} | Delete transaction         |
```

## 🛠️ Tech Stack
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger for API testing


## 📂 Project Structure
```
InventoryManagementSystem/
│── InventoryManagementSystem.sln          # Solution file
│
├── Controllers/                           # API Controllers (CRUD endpoints)
│   ├── CategoryController.cs
│   ├── SupplierController.cs
│   ├── ProductController.cs
│   └── StockTransactionController.cs
│
├── Models/                                # Contains Entities & DTOs
│   ├── Entities/                          # Database Models (Entities)
│   │   ├── Category.cs
│   │   ├── Supplier.cs
│   │   ├── Product.cs
│   │   └── StockTransaction.cs
│   │
│   ├── Dtos/                              # Data Transfer Objects
│       ├── CategoryDto.cs
│       ├── SupplierDto.cs
│       ├── ProductDto.cs
│       └── StockTransactionDto.cs
│
├── Data/                                  # Database Context
│   └── ApplicationDbContext.cs
│
├── Migrations/                            # EF Core Migrations
│
├── Properties/                            # Project properties
│
├── appsettings.json                       # Main configuration file
├── Program.cs                             # Application entry point
├── Startup.cs (if .NET 5) / Program.cs (if .NET 6+)  # Configurations
└── README.md                              # Documentation
```


## 📡 Here are some API Usage Examples

### 🔹 Product API

#### ➤ Create Product (POST `/api/product`)

**Request (JSON):**

```json
{
  "name": "Laptop",
  "description": "Dell XPS 13",
  "price": 1200.50,
  "quantity": 10,
  "categoryId": 1,
  "supplierId": 2
}
```

**Response (JSON):**

```json
{
  "id": 1,
  "name": "Laptop",
  "description": "Dell XPS 13",
  "price": 1200.50,
  "quantity": 10,
  "categoryId": 1,
  "supplierId": 2,
  "createdAt": "2025-09-20T12:30:00Z"
}
```

---

#### ➤ Get All Products (GET `/api/product`)

**Response (JSON):**

```json
[
  {
    "id": 1,
    "name": "Laptop",
    "description": "Dell XPS 13",
    "price": 1200.50,
    "quantity": 10,
    "categoryId": 1,
    "supplierId": 2
  },
  {
    "id": 2,
    "name": "Smartphone",
    "description": "iPhone 15 Pro",
    "price": 1500.00,
    "quantity": 5,
    "categoryId": 1,
    "supplierId": 3
  }
]
```

---

#### ➤ Update Product (PUT `/api/product/{id}`)

**Request (JSON):**

```json
{
  "name": "Laptop",
  "description": "Dell XPS 13 - Updated Model",
  "price": 1250.00,
  "quantity": 12,
  "categoryId": 1,
  "supplierId": 2
}
```

**Response (JSON):**

```json
{
  "id": 1,
  "name": "Laptop",
  "description": "Dell XPS 13 - Updated Model",
  "price": 1250.00,
  "quantity": 12,
  "categoryId": 1,
  "supplierId": 2,
  "updatedAt": "2025-09-20T13:15:00Z"
}
```

---

#### ➤ Delete Product (DELETE `/api/product/{id}`)

**Response (JSON):**

```json
{
  "message": "Product with ID 1 has been deleted successfully."
}
```





