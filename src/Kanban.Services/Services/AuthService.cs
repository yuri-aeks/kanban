using Kanban.Application.Interfaces;
using Kanban.Repository.Interfaces;
using Kanban.Model.ApplicationDto;
using Kanban.Model.Mapper.Auth;

namespace Kanban.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthDatabaseWorker _databaseWorker;
    public AuthService(IAuthDatabaseWorker databaseWorker) 
    { 
        _databaseWorker = databaseWorker;
    }

    public async Task RegisterClient(ClientDto client)
    {
        await _databaseWorker.RegisterClient(client.ToRepository());
    }

    public async Task<bool> Login(ClientDto client)
    {
        var dbClient = await _databaseWorker.GetClientById(client.Id);
        return dbClient is not null && dbClient.Secret == client.Secret;
    }
}
