# IPL eCommerce Web API

## Overview
This project is a **.NET 8.0 Web API** developed for an **IPL eCommerce platform** that sells merchandise for various IPL franchises. The API is built using **clean architecture principles** with best practices in mind.

## 📌 Features
- **Category Service**: Manages product categories.
- **Product Service**: Handles product creation, retrieval, and searching.
- **Franchise Service**: Manages IPL franchise-related information.
- **Cart Service**: Uses **MongoDB** to store user cart data.
- **Order Service**: Uses **MongoDB** to store order details.
- **Image Upload**: Utilizes **Azure Blob Storage** to store product images.
- **Database**:
  - **SQL Server** is used for `Category`, `Product`, and `Franchise` services.
  - **MongoDB** is used for `Cart` and `Order` services.
  - **Azure Blob Storage** is to store image in blob container

## 📂 API Endpoints
### **Category APIs**
- `POST /api/v1/Categories` → Create a new category
- `GET /api/v1/Categories` → Get all categories

### **Product APIs**
- `POST /api/Products` → Create a new product
- `GET /api/Products` → Get all products
- `GET /api/products/{id}` → Get product details
- `GET /api/products/search?name=cap&type=merchandise&franchise=CSK` → Search products

### **Cart & Order APIs** (Stored in MongoDB)
- `POST /api/cart` → Add item to cart
- `GET /api/cart/{userId}` → Get user’s cart items
- `POST /api/orders` → Place an order
- `GET /api/orders/{userId}` → Get user’s order history

## ⚙️ Setup & Running Instructions
### **1️⃣ Prerequisites**
- Install **.NET 8.0 SDK**
- Install **SQL Server** (or use an existing instance)
- Install **MongoDB**
- Setup **Azure Blob Storage**

### **2️⃣ Configuration**
- The API requires an `appsettings.json` file with database connection strings and Azure storage configurations.
- **Contact** [kiranpokharkar007@gmail.com](mailto:kiranpokharkar007@gmail.com) for the `appsettings.json` file.

### **3️⃣ Run the API**
#### **Using Visual Studio**
1. Open the solution in **Visual Studio 2022+**.
2. Set **ProductService.API** as the startup project.
3. Press **F5** to run the API.

#### **Using CLI**
```sh
cd ProductService

dotnet build

dotnet run --project ProductService.API
```
- The API will be available at:
  - **HTTP:** `http://localhost:5117`
  - **HTTPS:** `https://localhost:7117`

## 🛠️ Technologies Used
- **.NET 8.0 Web API**
- **Entity Framework Core (EF Core)**
- **SQL Server** (Relational Data)
- **MongoDB** (NoSQL for Cart & Orders)
- **Azure Blob Storage** (Image Uploads)
- **Swagger UI** for API documentation

## 📜 API Documentation
The API is documented using **Swagger**. After running the API, visit:
```
https://localhost:7117/swagger
```
---


