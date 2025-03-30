# Sample Markdown File

## Introduction
Design patterns are reusable solutions to common software design problems. They serve as blueprints for solving specific issues in object-oriented design and are widely used to make code more flexible, modular, and maintainable. The concept was popularized by the "Gang of Four" (GoF) book "Design Patterns: Elements of Reusable Object-Oriented Software."

## Features
Design patterns are generally categorized into three types:

- Creational Patterns: Focus on object creation mechanisms.
    Examples: Singleton, Factory Method, Abstract Factory, Builder, Prototype.
- Structural Patterns: Deal with the composition of objects or classes.
    Examples: Adapter, Bridge, Composite, Decorator, Facade, Flyweight, Proxy.
- Behavioral Patterns: Focus on communication between objects and how responsibilities are distributed.
    Examples: Observer, Strategy, Command, Chain of Responsibility, Template Method, Mediator.

## Example Code
PS G:\development>DesignPatterns
PS G:\development>cd DesignPatterns
PS G:\development\DesignPatterns>dotnet new sln
PS G:\development\DesignPatterns>mkdir src,test
PS G:\development\DesignPatterns\src> dotnet new classlib -n Pattern.Application
PS G:\development\DesignPatterns> dotnet sln .\DesignPatterns.sln add .\src\Pattern.Application\Pattern.Application.csproj
PS G:\development\DesignPatterns> dotnet sln .\DesignPatterns.sln add .\src\Pattern.Domain\Pattern.Domain.csproj          
PS G:\development\DesignPatterns> dotnet sln .\DesignPatterns.sln add .\src\Pattern.Infrastructure\Pattern.Infrastructure.csproj
PS G:\development\DesignPatterns> dotnet sln .\DesignPatterns.sln add .\src\Pattern.Presentation\Pattern.Presentation.csproj


-- Users Table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Products Table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Orders Table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- OrderDetails Table
CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Shipments Table
CREATE TABLE Shipments (
    ShipmentId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ShipmentDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL, -- e.g., Pending, Shipped, Delivered
    TrackingNumber NVARCHAR(100) NULL,
    Carrier NVARCHAR(100) NULL, -- e.g., FedEx, UPS
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);

-- ShipmentDetails Table
CREATE TABLE ShipmentDetails (
    ShipmentDetailId INT IDENTITY(1,1) PRIMARY KEY,
    ShipmentId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (ShipmentId) REFERENCES Shipments(ShipmentId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Insert sample users
INSERT INTO Users (FirstName, LastName, Email, PasswordHash)
VALUES 
('John', 'Doe', 'john.doe@example.com', 'hashedpassword1'),
('Jane', 'Smith', 'jane.smith@example.com', 'hashedpassword2');

-- Insert sample products
INSERT INTO Products (Name, Description, Price, Stock)
VALUES 
('Laptop', 'High-performance laptop', 1200.00, 10),
('Smartphone', 'Latest model smartphone', 800.00, 20),
('Headphones', 'Noise-cancelling headphones', 150.00, 50);

-- Insert a sample order
INSERT INTO Orders (UserId, TotalAmount)
VALUES (1, 1350.00);

-- Insert sample order details
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice)
VALUES 
(1, 1, 1, 1200.00), -- 1 Laptop
(1, 3, 1, 150.00);  -- 1 Headphones


PS G:\development\DesignPatterns\src\Pattern.Infrastructure> dotnet tool install --global dotnet-ef
You can invoke the tool using the following command: dotnet-ef
Tool 'dotnet-ef' (version '9.0.3') was successfully installed.

PS G:\development\DesignPatterns\src\Pattern.Infrastructure> dotnet add  package Microsoft.EntityFrameworkCore.Design                      
PS G:\development\DesignPatterns\src\Pattern.Presentation.API> dotnet add  package 
PS G:\development\DesignPatterns\src> cd .\Pattern.Infrastructure\
PS G:\development\DesignPatterns\src\Pattern.Infrastructure> dotnet ef migrations add InitialCreate --startup-project ..\Pattern.Presentation.API\
Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'TotalAmount' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'UnitPrice' on entity type 'OrderDetail'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'Price' on entity type 'Product'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
Done. To undo this action, use 'ef migrations remove'

PS G:\development\DesignPatterns\src\Pattern.Infrastructure> dotnet ef database update --startup-project ..\Pattern.Presentation.API\
Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'TotalAmount' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'UnitPrice' on entity type 'OrderDetail'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'Price' on entity type 'Product'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (159ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [ecommerce];
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (47ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [ecommerce] SET READ_COMMITTED_SNAPSHOT ON;
      END;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Migrations[20411]
      Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (14ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DECLARE @result int;
      EXEC @result = sp_getapplock @Resource = '__EFMigrationsLock', @LockOwner = 'Session', @LockMode = 'Exclusive';
      SELECT @result
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
      BEGIN
          CREATE TABLE [__EFMigrationsHistory] (
              [MigrationId] nvarchar(150) NOT NULL,
              [ProductVersion] nvarchar(32) NOT NULL,
              CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
          );
      END;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20250321183542_InitialCreate'.
Applying migration '20250321183542_InitialCreate'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Products] (
          [ProductId] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NULL,
          [Description] nvarchar(max) NULL,
          [Price] decimal(18,2) NOT NULL,
          [Stock] int NOT NULL,
          [CreatedAt] datetime2 NOT NULL,
          CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Users] (
          [UserId] int NOT NULL IDENTITY,
          [FirstName] nvarchar(max) NULL,
          [LastName] nvarchar(max) NULL,
          [Email] nvarchar(max) NULL,
          [PasswordHash] nvarchar(max) NULL,
          [CreatedAt] datetime2 NOT NULL,
          CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Orders] (
          [OrderId] int NOT NULL IDENTITY,
          [UserId] int NOT NULL,
          [OrderDate] datetime2 NOT NULL,
          [TotalAmount] decimal(18,2) NOT NULL,
          CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
          CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [OrderDetails] (
          [OrderDetailId] int NOT NULL IDENTITY,
          [OrderId] int NOT NULL,
          [ProductId] int NOT NULL,
          [Quantity] int NOT NULL,
          [UnitPrice] decimal(18,2) NOT NULL,
          CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailId]),
          CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
          CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Shipments] (
          [ShipmentId] int NOT NULL IDENTITY,
          [OrderId] int NOT NULL,
          [ShipmentDate] datetime2 NOT NULL,
          [Status] nvarchar(max) NULL,
          [TrackingNumber] nvarchar(max) NULL,
          [Carrier] nvarchar(max) NULL,
          CONSTRAINT [PK_Shipments] PRIMARY KEY ([ShipmentId]),
          CONSTRAINT [FK_Shipments_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [ShipmentDetails] (
          [ShipmentDetailId] int NOT NULL IDENTITY,
          [ShipmentId] int NOT NULL,
          [ProductId] int NOT NULL,
          [Quantity] int NOT NULL,
          CONSTRAINT [PK_ShipmentDetails] PRIMARY KEY ([ShipmentDetailId]),
          CONSTRAINT [FK_ShipmentDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
          CONSTRAINT [FK_ShipmentDetails_Shipments_ShipmentId] FOREIGN KEY ([ShipmentId]) REFERENCES [Shipments] ([ShipmentId]) ON DELETE CASCADE
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_OrderDetails_OrderId] ON [OrderDetails] ([OrderId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_OrderDetails_ProductId] ON [OrderDetails] ([ProductId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_ShipmentDetails_ProductId] ON [ShipmentDetails] ([ProductId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_ShipmentDetails_ShipmentId] ON [ShipmentDetails] ([ShipmentId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE UNIQUE INDEX [IX_Shipments_OrderId] ON [Shipments] ([OrderId]);
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20250321183542_InitialCreate', N'9.0.3');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DECLARE @result int;
      EXEC @result = sp_releaseapplock @Resource = '__EFMigrationsLock', @LockOwner = 'Session';
      SELECT @result
Done.

-- Insert sample users
INSERT INTO Users (FirstName, LastName, Email, PasswordHash, CreatedAt)
VALUES 
('John', 'Doe', 'john.doe@example.com', 'hashedpassword1', GETDATE()),
('Jane', 'Smith', 'jane.smith@example.com', 'hashedpassword2', GETDATE());

-- Insert sample products
INSERT INTO Products (Name, Description, Price, Stock, CreatedAt)
VALUES 
('Laptop', 'High-performance laptop', 1200.00, 10, GETDATE()),
('Smartphone', 'Latest model smartphone', 800.00, 20, GETDATE()),
('Headphones', 'Noise-cancelling headphones', 150.00, 50, GETDATE());

-- Insert a sample order
select * from Users
INSERT INTO Orders (UserId, TotalAmount,OrderDate)
VALUES (2, 1350.00, GETDATE());

-- Insert sample order details
select * from Orders
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice)
VALUES 
(3, 1, 1, 1200.00), -- 1 Laptop
(3, 3, 1, 150.00);  -- 1 Headphones

Shipment
GET         : http://localhost:5234//api/Shipment
GET         : http://localhost:5234//api/Shipment/{id}
POST        : http://localhost:5234//api/Shipment
PUT         : http://localhost:5234//api/Shipment/{id}
DELETE      : http://localhost:5234//api/Shipment/{id}

Shipment
GET /api/Shipment
Retrieve all shipments.
GET /api/Shipment/{id}
Retrieve a specific shipment by ID.
POST /api/Shipment
Create a new shipment.
PUT /api/Shipment/{id}
Update an existing shipment by ID.
DELETE /api/Shipment/{id}
Delete a shipment by ID.

Order
GET /api/Order
Retrieve all orders.
GET /api/Order/{id}
Retrieve a specific order by ID.
POST /api/Order
Create a new order.
PUT /api/Order/{id}
Update an existing order by ID.
DELETE /api/Order/{id}
Delete an order by ID.

ShipmentDetails
GET /api/ShipmentDetails
Retrieve all shipment details.
GET /api/ShipmentDetails/{id}
Retrieve specific shipment details by ID.
POST /api/ShipmentDetails
Create new shipment details.
PUT /api/ShipmentDetails/{id}
Update existing shipment details by ID.
DELETE /api/ShipmentDetails/{id}
Delete shipment details by ID.

Product
GET /api/Product
Retrieve all products.
GET /api/Product/{id}
Retrieve a specific product by ID.
POST /api/Product
Create a new product.
PUT /api/Product/{id}
Update an existing product by ID.
DELETE /api/Product/{id}
Delete a product by ID.

OrderDetails
GET /api/OrderDetails
Retrieve all order details.
GET /api/OrderDetails/{id}
Retrieve specific order details by ID.
POST /api/OrderDetails
Create new order details.
PUT /api/OrderDetails/{id}
Update existing order details by ID.
DELETE /api/OrderDetails/{id}
Delete order details by ID.

User
GET /api/User
Retrieve all users.
GET /api/User/{id}
Retrieve a specific user by ID.
POST /api/User
Create a new user.
PUT /api/User/{id}
Update an existing user by ID.
DELETE /api/User/{id}
Delete a user by ID.


GET /api/Shipment/{shipmentId}/Details
Retrieve all shipment details for a specific shipment.

GET /api/Shipment/{shipmentId}/Details/{detailId}
Retrieve a specific shipment detail by ID for a specific shipment.

POST /api/Shipment/{shipmentId}/Details
Create new shipment details for a specific shipment.

PUT /api/Shipment/{shipmentId}/Details/{detailId}
Update existing shipment details by ID for a specific shipment.

DELETE /api/Shipment/{shipmentId}/Details/{detailId}
Delete shipment details by ID for a specific shipment.



mkdir -p Product/Commands Product/Events Product/Queries
touch Product/Commands/CreateProductCommand.cs