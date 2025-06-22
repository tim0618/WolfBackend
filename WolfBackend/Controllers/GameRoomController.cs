using Microsoft.AspNetCore.Mvc;

namespace WolfGame.Controller;
[ApiController]
[Route("api/[controller]")]
public class GameRoomController : ControllerBase
{
    private readonly GameRoomService _gameRoomService;
    public GameRoomController(GameRoomService gameRoomService)
    {
        _gameRoomService = gameRoomService;
    }

    [HttpPost("CreateGameRoom")]
    public IActionResult CreateGameRoom()
    {
        if (_gameRoomService.CreateGameRoom()) return Ok();
        return BadRequest();
    }
}