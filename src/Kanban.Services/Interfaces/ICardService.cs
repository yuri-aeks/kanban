using Request = Kanban.Model.ControllerDto.Request.Card;
using Response = Kanban.Model.ControllerDto.Response.Card;

namespace Kanban.Application.Interfaces;

public interface ICardService
{
    public Task<List<Response.GetCardResponseDto>> GetAllCardsAsync();

    public Task<Response.GetCardResponseDto> GetCardByIdAsync(string id);

    public Task<Response.GetCardResponseDto> InsertCardAsync(Request.GetCardRequestDto card);
}
