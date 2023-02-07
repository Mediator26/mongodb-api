﻿using Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.Dtos;

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

    public async Task<List<User>> GetAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();
    public async Task<User?> GetAsync(DtoInputLogin dto) =>
        await _usersCollection.Find(x => x.Login == dto.Login).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);
}