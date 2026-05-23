# Machine Test 1 - Inventory Item Management Microservice

## Project Overview

This project is a RESTful Microservice developed using ASP.NET Core Web API and Entity Framework Core for managing Inventory Items.

The application provides CRUD operations along with Soft Delete functionality and SQL Server database integration.

---

## Technologies Used

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- Swagger UI
- Git & GitHub

---

## Functional Requirements Implemented

- Create Inventory Item
- Get Inventory Item by ID
- List All Inventory Items
- Update Inventory Item
- Soft Delete Inventory Item

---

## Database Fields

| Field Name | Type |
|------------|------|
| ItemId | Guid |
| ItemName | string |
| Category | string |
| Quantity | int |
| IsActive | bool |
| CreatedAt | datetime |
| UpdatedAt | datetime |

---

## API Endpoints

### Create Item

```http
POST /api/Inventory
