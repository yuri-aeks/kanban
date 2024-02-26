using App = Kanban.Model.ApplicationDto;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Card
{
    public static class ToRepositoryCardMapper
    {
        public static Repo.Card ToRepository(this App.CardDto card)
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
