using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OMDA.Database;
using OMDA.Models.Entities;

namespace OMDA.Services;

public class WorksService
{
    private readonly IMongoCollection<Work> _worksCollection;

    public WorksService(IOptions<DatabaseConnectionSettings> userStoreDatabaseSettings)
    {
        var mongoDatabase = DatabaseConnectionSettings.Connect(userStoreDatabaseSettings);

        _worksCollection = mongoDatabase.GetCollection<Work>("works");
    }

    public async Task<Work?> GetByIdAsync(string workId)
    {
        return await _worksCollection.Find(x => x.Id == workId).FirstOrDefaultAsync();
    }

    public async Task<List<Work>> GetAllFromUserAsync(string userId)
    {
        return await _worksCollection.Find(x => x.UserId == userId).ToListAsync();
    }

    public async Task<List<Work>> GetAllAcceptedByUserAsync(string userId)
    {
        return await _worksCollection.Find(x => x.AcceptedByUserId == userId).ToListAsync();
    }

    public async Task<List<Work>> GetAllAsync()
    {
        return await _worksCollection.Find(x => x.AcceptedByUserId == null && !x.Closed).ToListAsync();
    }

    public async Task CreateAsync(Work newWork)
    {
        await _worksCollection.InsertOneAsync(newWork);
    }
}