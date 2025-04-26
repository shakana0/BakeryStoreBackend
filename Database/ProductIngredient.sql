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
        ProductId INT NOT NULL,
        IngredientId INT NOT NULL,
        Quantity NVARCHAR (100) NOT NULL,
        PRIMARY KEY (ProductId, IngredientId),
        FOREIGN KEY (ProductId) REFERENCES Product (Id),
        FOREIGN KEY (IngredientId) REFERENCES Ingredient (Id)
    );

END