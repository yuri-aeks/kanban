using Kanban.Model.ControllerDto.Request.Auth;
using Kanban.Application.Interfaces;
using Kanban.CrossCutting;
using Microsoft.AspNetCore.Mvc;
using Kanban.Model.Mapper.Auth;

namespace Kanban.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(ClientDto client)
    {
        await _authService.RegisterClient(client.ToApplication());
        return new OkObjectResult(Constants.ClientRegitered);
    }
}
