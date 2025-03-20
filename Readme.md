# Sample Markdown File

## Introduction
This is a sample Markdown file. Markdown is a lightweight markup language for creating formatted text using a plain-text editor.

## Features
- Easy to write and read
- Supports headings, lists, links, and more
- Widely used for documentation

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