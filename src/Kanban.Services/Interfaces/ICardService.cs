using Kanban.Model.ControllerDto.Request.Card;

namespace Kanban.Application.Interfaces;

public interface ICardService
{
    public Task<List<CardDto>> GetAllCardsAsync();

    public Task<CardDto> GetCardByIdAsync(string id);

    public Task<CardDto> InsertCardAsync(CardDto card);
}
