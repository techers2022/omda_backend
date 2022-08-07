﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OMDA.Database;
using OMDA.Models.Entities;

namespace OMDA.Services;

public class UsersService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(IOptions<DatabaseConnectionSettings> userStoreDatabaseSettings)
    {
        var mongoDatabase = DatabaseConnectionSettings.Connect(userStoreDatabaseSettings);

        _usersCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<List<User>> GetAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);
}