using App = Kanban.Model.ApplicationDto;
using Api = Kanban.Model.ControllerDto.Request.Auth;

namespace Kanban.Model.Mapper.Request.Auth;

public static class ToApplicationClientMapper
{
    public static App.ClientDto ToApplication(this Api.ClientDto client)
    {
        return new App.ClientDto
        {
            Id = client.Id,
            Secret = client.Secret,
        };
    }
}
