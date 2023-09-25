using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.ViewModels
{
	public class GameResultViewModel
	{
        public Guid	SecretId { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }
        public byte Result { get; set; }
        public string Moves { get; set; }
    }
}
