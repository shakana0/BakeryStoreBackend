CREATE TABLE [dbo].[ProductIngredient]
(
	ProductId INT NOT NULL,
    IngredientId INT NOT NULL,
    Quantity NVARCHAR(100) NOT NULL,
    PRIMARY KEY (ProductId, IngredientId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (IngredientId) REFERENCES Ingredient(Id)
)
