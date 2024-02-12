using Kanban.Repository.Dto.Models;

namespace Kanban.Repository.Interfaces
{
    public interface IKanbanDatabaseWorker
    {
        public Task<CardDto?> GetCardByIdAsync(string id);
        
        public Task<List<CardDto>> GetAllCardsAsync();

        public Task<CardDto> InsertCardAsync(CardDto card);

        public Task<CardDto?> UpdateCard(CardDto card);

        public Task<long> UpdateManyDescriptions(List<string> ids, string description);

        public Task<bool> DeleteById(string id);
    }
}
