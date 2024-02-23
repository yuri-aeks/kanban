namespace Kanban.Model.ControllerDto.Request.Auth;

public class CreateClientRequestDto
{
    public string Id { get; set; } = string.Empty;

    public string Secret { get; set; } = string.Empty;
}
