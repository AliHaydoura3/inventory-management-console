# Inventory Management System

A simple C# console application for managing a product inventory in memory.

## Features

- **Add a product** — name, price, and quantity (duplicate names are rejected)
- **View products** — list all products with price and quantity
- **Restock a product** — increase the quantity of an existing product
- **Sell a product** — decrease quantity (with insufficient-stock check)
- **Remove a product** — delete a product from the inventory
- Input validation for price and quantity (non-numeric input is rejected)

## Getting Started

### Prerequisites

- .NET 9 SDK

### Run

```bash
dotnet run
```

Follow the menu prompts (options 1–6).

## Project Structure

```
Program.cs                         All app logic (menu, product lists, operations)
InventoryManagementSystem.csproj   Project file (net9.0 console app)
InventoryManagementSystem.sln      Visual Studio solution
```

## Author

Ali Haydoura