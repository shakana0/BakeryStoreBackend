IF NOT EXISTS (
    SELECT
        *
    FROM
        INFORMATION_SCHEMA.TABLES
    WHERE
        TABLE_NAME = 'ProductIngredient'
) BEGIN
CREATE TABLE
    ProductIngredient (
        Id INT IDENTITY (1, 1) PRIMARY KEY,
        ProductId INT NOT NULL,
        IngredientId INT NOT NULL,
        Quantity DECIMAL(10, 2) NOT NULL,
        Unit NVARCHAR (50) NOT NULL,
        Description NVARCHAR (255) NULL,
        FOREIGN KEY (ProductId) REFERENCES Product (Id),
        FOREIGN KEY (IngredientId) REFERENCES Ingredient (Id)
    );

END