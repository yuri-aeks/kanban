using Kanban.Model.RepositoryDto;

namespace Kanban.Repository.Interfaces
{
    public interface IAuthDatabaseWorker
    {
        public Task<Client?> GetClientById(string id);

        public Task RegisterClient(Client client);
    }
}
