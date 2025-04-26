IF NOT EXISTS (
    SELECT
        *
    FROM
        INFORMATION_SCHEMA.TABLES
    WHERE
        TABLE_NAME = 'Category'
) BEGIN
CREATE TABLE
    Category (
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Name NVARCHAR (100) NOT NULL
    );

END