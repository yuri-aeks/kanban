using Kanban.Model.ApplicationDto;

namespace Kanban.Model.ControllerDto.Response;

public class GetCardListResponseDto
{
    public List<CardDto> cards {  get; set; } = new List<CardDto>();
}
