Create database InventorySystem
Use InventorySystem

CREATE TABLE Users(
	Id uniqueidentifier PRIMARY KEY,
	Username NVARCHAR(100) NOT NULL,
	Password NVARCHAR(100) NOT NULL
);
CREATE TABLE Products (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ProductCode NVARCHAR(100) NOT NULL,
    ProductName NVARCHAR(255) NOT NULL,
    ProductImage VARBINARY(MAX),
    CreatedDate DATETIMEOFFSET ,
    UpdatedDate DATETIMEOFFSET ,
    CreatedUser UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(Id),
    IsFavourite BIT DEFAULT 0,
    Active BIT DEFAULT 1,
    HSNCode NVARCHAR(100),
    TotalStock DECIMAL(18, 2) DEFAULT 0
);
CREATE TABLE Variants (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ProductId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Products(Id),
    VariantName NVARCHAR(100) NOT NULL
);
CREATE TABLE SubVariants (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    VariantId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Variants(Id),
    SubVariantName NVARCHAR(100) NOT NULL,
    Stock DECIMAL(18, 2) DEFAULT 0
);
SELECT * FROM Products
SELECT * FROM Variants
SELECT * FROM SubVariants