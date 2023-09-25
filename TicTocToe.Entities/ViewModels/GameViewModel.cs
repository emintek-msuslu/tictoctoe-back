using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.ViewModels
{
	public class GameViewModel
	{
		public Guid Id { get; set; }
		public string FirstPlayerName { get; set; }
		public string SecondPlayerName { get; set; }
		public bool FirstPlayerType { get; set; } // true : X ; false : O
	}
}
