using Api = Kanban.Model.ControllerDto.Request.Card;
using App = Kanban.Model.ApplicationDto;

namespace Kanban.Model.Mapper.Card
{
    public static class ToApplicationCardMapper
    {
        public static App.CardDto ToApplication(this Api.GetCardRequestDto client)
        {
            return new App.CardDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = client.Name,
                Description = client.Description,
            };
        }
    }
}
