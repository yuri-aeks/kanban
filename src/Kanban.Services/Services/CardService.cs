using Kanban.Model.Mapper.Card;
using Kanban.Application.Interfaces;
using Kanban.Repository.Interfaces;

using Request = Kanban.Model.ControllerDto.Request.Card;
using Response = Kanban.Model.ControllerDto.Response.Card;

namespace Kanban.Application.Services;
public class CardService : ICardService
{
    private readonly IKanbanDatabaseWorker _kanbanDatabaseWorker;

    public CardService(IKanbanDatabaseWorker kanbanDatabaseWorker)
    {
        this._kanbanDatabaseWorker = kanbanDatabaseWorker;
    }

    public async Task<Response.GetCardResponseDto> GetCardByIdAsync(string id)
    {
        var card = await this._kanbanDatabaseWorker.GetCardByIdAsync(id);
        return card is null ? new Response.GetCardResponseDto() : card.ToController();
    }

    public async Task<List<Response.GetCardResponseDto>> GetAllCardsAsync()
    {
        var cards = await this._kanbanDatabaseWorker.GetAllCardsAsync();
        return cards is null ? new List<Response.GetCardResponseDto>() : cards.ToControllerList();
    }

    public async Task<Response.GetCardResponseDto> InsertCardAsync(Request.GetCardRequestDto card)
    {
        var applicationCard = card.ToApplication();
        var insertedCard = await this._kanbanDatabaseWorker.InsertCardAsync(applicationCard.ToRepository());
        return insertedCard is null ? new Response.GetCardResponseDto() : insertedCard.ToController();
    }
}