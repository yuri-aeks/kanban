using Api = Kanban.Model.ControllerDto.Response.Card;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Card;

public static class ToControllerCardMapper
{
    public static List<Api.GetCardResponseDto> ToControllerList(this List<Repo.Card> cards)
    {
        return cards.Select(card => card.ToController()).ToList();
    }

    public static Api.GetCardResponseDto ToController(this Repo.Card card) 
    {
        Api.GetCardResponseDto apiCard = new Api.GetCardResponseDto
        {
            Id = card.Id,
            Name = card.Name,
            Description = card.Description,
        };

        return apiCard;
    }
}
