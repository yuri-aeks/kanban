using Repo = Kanban.Repository.Dto.Models;
using App = Kanban.Application.Dto.Models;
using Api = Kanban.API.Dto.Card;

namespace Kanban.Application.Dto.Mapper
{
    public static class CardMapper
    {
        public static App.CardDto RepoToApp(this Repo.CardDto card)
        {
            App.CardDto appCard = new App.CardDto
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
            };

            return appCard;
        }

        public static List<App.CardDto> RepoListToAppList(this List<Repo.CardDto> cards)
        {
            return cards.Select(card => card.RepoToApp()).ToList();
        }

        public static Repo.CardDto AppToRepo(this App.CardDto card)
        {
            Repo.CardDto repoCard = new Repo.CardDto
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
            };

            return repoCard;
        }

        public static List<Repo.CardDto> AppListToRepoList(this List<App.CardDto> cards)
        {
            return cards.Select(card => card.AppToRepo()).ToList();
        }

        public static App.CardDto ApiToApp(this Api.CardDto card)
        {
            App.CardDto appCard = new App.CardDto
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
            };

            return appCard;
        }

        public static List<App.CardDto> ApiListToAppList(this List<Api.CardDto> cards)
        {
            return cards.Select(card => card.ApiToApp()).ToList();
        }
    }
}
