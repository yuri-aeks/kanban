using Kanban.Application.Dto.Mapper;
using Kanban.Application.Dto.Models;
using Kanban.Application.Interfaces;
using Kanban.Repository.Interfaces;

namespace Kanban.Application.Services;
public class CardService : ICardService
{
    private readonly IKanbanDatabaseWorker _kanbanDatabaseWorker;

    public CardService(IKanbanDatabaseWorker kanbanDatabaseWorker)
    {
        this._kanbanDatabaseWorker = kanbanDatabaseWorker;
    }

    public async Task<CardDto> GetCardByIdAsync(string id)
    {
        var card = await this._kanbanDatabaseWorker.GetCardByIdAsync(id);
        return card is null ? new CardDto() : card.RepoToApp();
    }

    public async Task<List<CardDto>> GetAllCardsAsync()
    {
        var cards = await this._kanbanDatabaseWorker.GetAllCardsAsync();
        return cards is null ? new List<CardDto>() : cards.RepoListToAppList();
    }

    public async Task<CardDto> InsertCardAsync(CardDto card) 
    {
        var insertedCard = await this._kanbanDatabaseWorker.InsertCardAsync(card.AppToRepo());
        return insertedCard is null ? new CardDto() : insertedCard.RepoToApp();
    }
}