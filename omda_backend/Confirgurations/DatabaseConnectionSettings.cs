using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace OMDA.Configurations;

public class DatabaseConnectionSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public static IMongoDatabase Connect(IOptions<DatabaseConnectionSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        return mongoDatabase;
    }
}