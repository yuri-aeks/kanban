using Kanban.API.Dto.Card;
using Kanban.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Kanban.API.Mapper;
using Microsoft.AspNetCore.Authorization;
using Kanban.API.Authentication;
using Kanban.Application.Dto.Mapper;

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
        return cards.ToPresentationResponse();
    }

    [HttpGet("{id}"), CustomAuthentication]
    public async Task<ActionResult<CardResponseDto>> GetCard([FromRoute] string id)
    {
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Start", new { id });
        var card = await _cardService.GetCardByIdAsync(id);
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Result", new { card });
        return card.ToPresentationResponse();
    }

    [HttpPost(), CustomAuthentication]
    public async Task<ActionResult<CardResponseDto>> InsertCard([FromBody] CardDto card)
    {
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Start", new { card });
        var insertedCard = await _cardService.InsertCardAsync(card.ApiToApp());
        this._logger.LogInformation($"{nameof(CardController)}.{nameof(GetCard)}: Result", new { insertedCard });
        return insertedCard.ToPresentationResponse();
    }
}