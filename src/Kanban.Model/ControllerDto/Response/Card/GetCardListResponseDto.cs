namespace Kanban.Model.ControllerDto.Response.Card;

public class GetCardListResponseDto
{
    public List<GetCardResponseDto> cards { get; set; } = new List<GetCardResponseDto>();
}
