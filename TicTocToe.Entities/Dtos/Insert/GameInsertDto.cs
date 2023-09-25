using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.Dtos.Insert
{
	public class GameInsertDto
	{
        public string FirstPlayerName { get; set; }
		public string SecondPlayerName { get; set; }
        public bool FirstPlayerType { get; set; } // true : X ; false : O
	}
}
