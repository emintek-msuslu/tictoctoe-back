using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicTocToe.Bll.Abstract;
using TicTocToe.Model.Dtos.Insert;
using TicTocToe.Model.Dtos.Update;
using TicTocToe.Model.Entities;
using TicTocToe.Model.ViewModels;
using TicTocToe.WebApi.Helper;

namespace TicTocToe.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameController : ControllerBase
	{
		protected readonly IConfiguration _configuration;
		protected readonly ILogger _logger;
		private IGameService _gameService;
		public GameController(ILogger<GameController> logger, IConfiguration configuration, IGameService gameService) 
		{ 
			_logger = logger;
			_configuration = configuration;	
			_gameService = gameService;
		}
		[HttpGet]
		public Game Get()
		{
			return new Game() { Id = 1,FirstPlayerName = "a", FirstPlayerType = true, SecondlayerName = "b" };
		}

		[HttpPost]
		public async Task<AuthResponse<GameViewModel>> Post(GameInsertDto game)
		{
			if (Request.Headers["keycode"] == "X4d3g7P1k9zZwE6sO8yA2nG5hL0mQ3jF")
			{
				GameViewModel data = await _gameService.CreateGameAndResponse(game);
				var token = WebApiHelper.GenerateJwtToken(_configuration);
				return new AuthResponse<GameViewModel>() { Data = data, Token = token };
			}
			else
			{
				return null;
			}


		}

		[Authorize]
		[HttpPost("UpdateGame")]
		public async Task<AuthResponse<GameResultViewModel>> Update(GameUpdateDto game)
		{
			GameResultViewModel data = await _gameService.UpdateGameAndResponse(game);
			var token = WebApiHelper.GenerateJwtToken(_configuration);
			return new AuthResponse<GameResultViewModel>() { Data = data, Token = token };
		}

	}
}
