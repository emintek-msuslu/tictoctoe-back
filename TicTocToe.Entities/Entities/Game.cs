using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Core.Concrete;

namespace TicTocToe.Model.Entities
{
	public class Game : BaseEntity
	{
		public string FirstPlayerName { get; set; } // Name of First Player
		public string SecondlayerName { get; set; } // Name of Second Player
		public bool FirstPlayerType { get; set; } // true when FP is X
		public string Moves { get; set; } = "";// cells will be considered as an element of matrix i.e a00 -> 0 a01 -> 1 --- a33 ->9
		public bool Status { get; set; } = false; // false before game start
		public byte Result { get; set; } = 0; // NS 0 - FP 1 - DR 2 - SP 3
	}
}
