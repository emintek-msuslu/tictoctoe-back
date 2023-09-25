using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Bll.Abstract;
using TicTocToe.Dal.Data.Abstract;
using TicTocToe.Model.Core.Concrete;
using TicTocToe.Model.Dtos.Insert;
using TicTocToe.Model.Dtos.Update;
using TicTocToe.Model.Entities;
using TicTocToe.Model.ViewModels;

namespace TicTocToe.Bll.Concrete
{
	public class GameManager : GenericManager<Game, IDalGame>, IGameService
	{
		public GameManager(IDalGame dal) : base(dal)
		{

		}

		public async Task<GameViewModel> CreateGameAndResponse(GameInsertDto game)
		{
			Game newGame = new Game() { FirstPlayerName = game.FirstPlayerName, SecondlayerName = game.SecondPlayerName, FirstPlayerType = game.FirstPlayerType };
			ResultModel<Game> result = await _dal.CreateAsync(newGame);
			if (result.Success)
			{
				GameViewModel model = new GameViewModel() { FirstPlayerName = result.Data.FirstPlayerName, Id = result.Data.SecretId, FirstPlayerType = result.Data.FirstPlayerType, SecondPlayerName = result.Data.SecondlayerName };
				return model;
			}
			else
			{
				return null;
			}

		}

		public async Task<GameResultViewModel> UpdateGameAndResponse(GameUpdateDto game)
		{
			ResultModel<Game> result = await _dal.GetOneAsync(x => x.SecretId == game.Id);
			if (result.Success)
			{
				result.Data.Status = true;
				result.Data.Moves = game.Moves;
				result.Data.UpdateDate = DateTime.Now;
				result.Data.Result = game.Result;
				ResultModel<Game> model = await _dal.UpdateAsync(result.Data);
				if (model.Success)
				{
					return new GameResultViewModel()
					{
						FirstPlayerName = model.Data.FirstPlayerName,
						Moves = model.Data.Moves,
						Result = model.Data.Result,
						SecondPlayerName = model.Data.SecondlayerName,
						SecretId = model.Data.SecretId
					};
				}
				else
				{
					return new GameResultViewModel();
				}
			}
			else
			{
				return null;
			}
		}
	}
}
