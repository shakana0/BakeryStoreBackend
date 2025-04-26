IF NOT EXISTS (
    SELECT
        *
    FROM
        INFORMATION_SCHEMA.TABLES
    WHERE
        TABLE_NAME = 'Product'
) BEGIN
CREATE TABLE
    Product (
        Id INT IDENTITY (1, 1) PRIMARY KEY,
        Name NVARCHAR (100) NOT NULL,
        Description NVARCHAR (MAX),
        Price DECIMAL(18, 2) NOT NULL,
        Stock INT NOT NULL DEFAULT 0,
        CategoryId INT NOT NULL,
        FOREIGN KEY (CategoryId) REFERENCES Category (Id)
    );

END