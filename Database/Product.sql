CREATE TABLE [dbo].[Product]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2) NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
