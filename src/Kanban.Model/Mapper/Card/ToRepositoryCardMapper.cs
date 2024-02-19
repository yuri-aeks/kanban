using Api = Kanban.Model.ControllerDto.Request.Card;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Card
{
    public static class ToRepositoryCardMapper
    {
        public static Repo.Card ToRepository(this Api.CardDto card)
        {
            Repo.Card apiCard = new Repo.Card
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
            };

            return apiCard;
        }
    }
}
