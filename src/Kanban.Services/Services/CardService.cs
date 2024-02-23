using Kanban.Model.Mapper.Card;
using Kanban.Application.Interfaces;
using Kanban.Repository.Interfaces;

using Kanban.Model.ControllerDto.Request.Card;
using Kanban.Model.ControllerDto.Response.Card;

namespace Kanban.Application.Services;
public class CardService : ICardService
{
    private readonly IKanbanDatabaseWorker _kanbanDatabaseWorker;

    public CardService(IKanbanDatabaseWorker kanbanDatabaseWorker)
    {
        this._kanbanDatabaseWorker = kanbanDatabaseWorker;
    }

    public async Task<GetCardResponseDto> GetCardByIdAsync(string id)
    {
        var card = await this._kanbanDatabaseWorker.GetCardByIdAsync(id);
        return card is null ? new GetCardResponseDto() : card.ToController();
    }

    public async Task<GetCardListResponseDto> GetAllCardsAsync()
    {
        var cards = await this._kanbanDatabaseWorker.GetAllCardsAsync();
        return cards is null ? new GetCardListResponseDto() : new GetCardListResponseDto{ cards = cards.ToControllerList() };
    }

    public async Task<GetCardResponseDto> InsertCardAsync(GetCardRequestDto card)
    {
        var applicationCard = card.ToApplication();
        var insertedCard = await this._kanbanDatabaseWorker.InsertCardAsync(applicationCard.ToRepository());
        return insertedCard is null ? new GetCardResponseDto() : insertedCard.ToController();
    }
}