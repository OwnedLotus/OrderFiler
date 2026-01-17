# OrderFiler

A C# Windows Forms application for managing orders with SQLite database storage.

## Features

- **Order Management**: Create, update, and delete orders
- **Search**: Search by order number or PO number
- **Database**: SQLite database with Entity Framework Core
- **Printing**: Print open orders
- **Auto-cleanup**: Automatically removes deleted orders after 2 weeks

## Quick Start

```bash
# Build and run
dotnet run

# Build for release
dotnet build -c Release

# Publish
dotnet publish -c Release --self-contained
```

## Order Model

- **Order Number**: Unique identifier (uint)
- **PO Number**: Purchase order number (string)
- **Shipping Method**: CPUP, BACKORDER, or SHIPPING
- **Status**: Pulled/unpulled flag
- **Soft Delete**: Orders marked as deleted are retained for 2 weeks

## Requirements

- .NET 10.0 Windows
- Windows Forms
- SQLite

## Database

Uses SQLite (`orders.db`) with Entity Framework Core for data persistence.