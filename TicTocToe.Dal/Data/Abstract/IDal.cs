using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Entities;
using TicTocToe.Repo.Abstract;

namespace TicTocToe.Dal.Data.Abstract
{

	public interface IDalGame : IRepositoryAsync<Game>
	{
	}
}
