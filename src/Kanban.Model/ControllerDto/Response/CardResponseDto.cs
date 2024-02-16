using Kanban.Model.ApplicationDto;

namespace Kanban.Model.ControllerDto.Response;

public class CardResponseDto
{
    public List<CardDto> cards {  get; set; } = new List<CardDto>();
}
