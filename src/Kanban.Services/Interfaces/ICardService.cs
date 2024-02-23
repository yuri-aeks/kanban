using Kanban.Model.ControllerDto.Request.Card;
using Kanban.Model.ControllerDto.Response.Card;

namespace Kanban.Application.Interfaces;

public interface ICardService
{
    public Task<GetCardListResponseDto> GetAllCardsAsync();

    public Task<GetCardResponseDto> GetCardByIdAsync(string id);

    public Task<GetCardResponseDto> InsertCardAsync(GetCardRequestDto card);
}
