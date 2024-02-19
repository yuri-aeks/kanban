using Api = Kanban.Model.ControllerDto.Request.Card;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Card;

public static class ToControllerCardMapper
{
    public static List<Api.CardDto> ToControllerList(this List<Repo.Card> cards)
    {
        return cards.Select(card => card.ToController()).ToList();
    }

    public static Api.CardDto ToController(this Repo.Card card) 
    {
        Api.CardDto apiCard = new Api.CardDto
        {
            Id = card.Id,
            Name = card.Name,
            Description = card.Description,
        };

        return apiCard;
    }
}
