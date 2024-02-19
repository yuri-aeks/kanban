using Kanban.API.Authentication;
using Kanban.Application.Interfaces;
using Kanban.Model.ControllerDto.Request.Card;
using Kanban.Model.ControllerDto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ILogger<CardController> _logger;
    private readonly ICardService _cardService;

    public CardController(ILogger<CardController> logger, ICardService cardService)
    {
        _logger = logger;
        _cardService = cardService;
    }

    [HttpGet, CustomAuthentication]
    public async Task<ActionResult<CardResponseDto>> GetAllCards()
    {
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetAllCards)}: Start");
        var cards = await _cardService.GetAllCardsAsync();
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetAllCards)}: Result", new { cards });
        return new OkObjectResult (cards);
    }

    [HttpGet("{id}"), CustomAuthentication]
    public async Task<ActionResult<CardResponseDto>> GetCard([FromRoute] string id)
    {
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Start", new { id });
        var card = await _cardService.GetCardByIdAsync(id);
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Result", new { card });
        return new OkObjectResult(card);
    }

    [HttpPost(), CustomAuthentication]
    public async Task<ActionResult<CardResponseDto>> InsertCard([FromBody] CardDto card)
    {
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Start", new { card });
        var insertedCard = await _cardService.InsertCardAsync(card);
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Result", new { insertedCard });
        return new OkObjectResult(insertedCard);
    }
}