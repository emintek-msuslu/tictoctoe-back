using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Dtos.Insert;
using TicTocToe.Model.Dtos.Update;
using TicTocToe.Model.Entities;
using TicTocToe.Model.ViewModels;

namespace TicTocToe.Bll.Abstract
{
	
	public interface IGameService : IServiceBase<Game>
	{
		public Task<GameViewModel> CreateGameAndResponse(GameInsertDto game);
		public Task<GameResultViewModel> UpdateGameAndResponse(GameUpdateDto game);
    }
}
