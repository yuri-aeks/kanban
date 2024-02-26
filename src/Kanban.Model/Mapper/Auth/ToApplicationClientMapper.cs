using App = Kanban.Model.ApplicationDto;
using Api = Kanban.Model.ControllerDto.Request.Auth;

namespace Kanban.Model.Mapper.Auth;

public static class ToApplicationClientMapper
{
    public static App.ClientDto ToApplication(this Api.CreateClientRequestDto client)
    {
        return new App.ClientDto
        {
            Id = client.Id,
            Secret = client.Secret,
        };
    }
}
