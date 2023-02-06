using Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Services;

public class UsersServices
{
    private readonly IMongoCollection<User> _usersCollection;
    public UsersServices(
        IOptions<UsersDatabaseSettings> userDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            userDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            userDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(
            userDatabaseSettings.Value.UsersCollectionName);
    }

    public async Task<List<User>> GetAsync() => await _usersCollection.
}