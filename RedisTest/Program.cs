
class Program
{
    static async Task Main()
    {
        // 🔹 Load Configuration
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "../.env" }));

        var redisHostName = Environment.GetEnvironmentVariable("REDIS_HOSTNAME");
        var redisPort = Environment.GetEnvironmentVariable("REDIS_PORT");
        var redisAccessKey = Environment.GetEnvironmentVariable("REDIS_ACCESS_KEY"); ;

        try
        {
            // 🔹 Configure Redis Connection with Access Key
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { $"{redisHostName}:{redisPort}" },
                Password = redisAccessKey, // 🔹 Use access key for authentication
                Ssl = true,
                ConnectTimeout = 20000, // 🔹 Increase timeout to 15 sec
                SyncTimeout = 20000,    // 🔹 Increase sync timeout
                AbortOnConnectFail = false // 🔹 Allow retries automatically
            };

            var connection = await ConnectionMultiplexer.ConnectAsync(configurationOptions);
            Console.WriteLine("Connected to Redis successfully!");

            // 🔹 Test Redis by Setting & Getting a Key
            var db = connection.GetDatabase();
            await db.StringSetAsync("TestKey", "Hello from Redis!");
            var value = await db.StringGetAsync("TestKey");

            Console.WriteLine($"Retrieved value from Redis: {value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Redis connection failed: {ex.Message}");
        }
    }
}
