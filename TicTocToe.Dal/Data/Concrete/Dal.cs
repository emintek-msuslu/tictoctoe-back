using TicTocToe.Dal.Contexts;
using TicTocToe.Dal.Data.Abstract;
using TicTocToe.Model.Entities;
using TicTocToe.Repo.Concrete;

namespace TicTocToe.Dal.Data.Concrete
{
	public class DalGame : RepositoryAsync<Game , TicTocToeDbContext>, IDalGame
	{
		public DalGame(TicTocToeDbContext ctx) : base(ctx)
		{

		}
	}
}
