IF NOT EXISTS (
    SELECT
        *
    FROM
        INFORMATION_SCHEMA.TABLES
    WHERE
        TABLE_NAME = 'Ingredient'
) BEGIN
CREATE TABLE
    Ingredient (
        Id INT IDENTITY (1, 1) PRIMARY KEY,
        Name NVARCHAR (100) NOT NULL,
        Allergens NVARCHAR (255) NULL
    );

END