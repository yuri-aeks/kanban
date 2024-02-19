using Kanban.Model.RepositoryDto;

namespace Kanban.Repository.Interfaces
{
    public interface IKanbanDatabaseWorker
    {
        public Task<Card?> GetCardByIdAsync(string id);
        
        public Task<List<Card>> GetAllCardsAsync();

        public Task<Card> InsertCardAsync(Card card);

        public Task<Card?> UpdateCard(Card card);

        public Task<long> UpdateManyDescriptions(List<string> ids, string description);

        public Task<bool> DeleteByIdAsync(string id);
    }
}
