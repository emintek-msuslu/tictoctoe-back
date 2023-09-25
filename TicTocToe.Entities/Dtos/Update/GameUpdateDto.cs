using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.Dtos.Update
{
	public class GameUpdateDto
	{
		public Guid Id { get; set; }
        public string Moves { get; set; }
        public byte Result { get; set; }    

    }
	public class GameUpdateDto2
	{
		public string Id { get; set; }
		public string Moves { get; set; }
		public byte Result { get; set; }

	}
}
