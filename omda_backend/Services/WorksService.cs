using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OMDA.Configurations;
using OMDA.Models.Entities;

namespace OMDA.Services;

public class WorksService
{
    private readonly IMongoCollection<Work> _worksCollection;
    private readonly TwilioService _twilioService;
    private readonly UsersService _usersService;

    public WorksService(IOptions<DatabaseConnectionSettings> userStoreDatabaseSettings, TwilioService twilioService, UsersService usersService)
    {
        var mongoDatabase = DatabaseConnectionSettings.Connect(userStoreDatabaseSettings);

        _worksCollection = mongoDatabase.GetCollection<Work>("works");

        _twilioService = twilioService;
        _usersService = usersService;
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

    public async Task AcceptWorkByUserAsync(string workId, string userId)
    {
        var work = await _worksCollection.Find(x => x.Id == workId).FirstOrDefaultAsync();
        
        work.AcceptedByUserId = userId;

        await _worksCollection.ReplaceOneAsync(x => x.Id == workId, work);

        var user = await _usersService.GetUserByIdAsync(userId);

        await _twilioService.SendMessageAsync($"OMDA: Anunţul dumneavoastră \"{work.Title}\" a fost acceptat de catre {user.LastName} {user.FirstName}", $"+4{user.Phone}");
    }

    public async Task CreateAsync(Work newWork)
    {
        await _worksCollection.InsertOneAsync(newWork);
    }
}