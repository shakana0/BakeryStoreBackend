using Microsoft.EntityFrameworkCore;

public static class SqlScriptRunner
{
    public static void ExecuteDatabaseScripts(DbContext dbContext)
    {
        var databasePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Database"));

        if (!Directory.Exists(databasePath))
        {
            Console.WriteLine($"Database folder not found: {databasePath}");
            return;
        }

        var categoryScriptPath = Path.Combine(databasePath, "Category.sql");
        var ingredientScriptPath = Path.Combine(databasePath, "Ingredient.sql");
        var productScriptPath = Path.Combine(databasePath, "Product.sql");
        var productIngredientScriptPath = Path.Combine(databasePath, "ProductIngredient.sql");

        if (!Directory.Exists(databasePath))
        {
            Console.WriteLine($"Database folder not found: {databasePath}");
            return;
        }
        if (!TableExists(dbContext, "Category"))
        {
            ExecuteSqlFile(dbContext, categoryScriptPath);
        }

        if (!TableExists(dbContext, "Ingredient"))
        {
            ExecuteSqlFile(dbContext, ingredientScriptPath);
        }

        if (!TableExists(dbContext, "Product"))
        {
            ExecuteSqlFile(dbContext, productScriptPath);
        }

        if (!TableExists(dbContext, "ProductIngredient"))
        {
            ExecuteSqlFile(dbContext, productIngredientScriptPath);
        }

        var sqlFiles = Directory.GetFiles(databasePath, "*.sql").Where(f => f != categoryScriptPath && f != ingredientScriptPath && f != productScriptPath && f != productIngredientScriptPath);

        // Run remaining SQL scripts
        foreach (var file in sqlFiles)
        {
            ExecuteSqlFile(dbContext, file);
        }

        dbContext.SaveChanges();
    }

    private static void ExecuteSqlFile(DbContext dbContext, string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                Console.WriteLine($"Executing SQL script: {filePath}");
                dbContext.Database.ExecuteSqlRaw(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SQL script {filePath}: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"SQL script file not found: {filePath}");
        }
    }
    private static bool TableExists(DbContext dbContext, string tableName)
    {
        var query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";

        using (var command = dbContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            dbContext.Database.OpenConnection();

            var result = command.ExecuteScalar();
            dbContext.Database.CloseConnection();

            int count = Convert.ToInt32(result);
            Console.WriteLine($"Checking if table '{tableName}' exists: {count > 0}");
            return count > 0;
        }
    }
}
