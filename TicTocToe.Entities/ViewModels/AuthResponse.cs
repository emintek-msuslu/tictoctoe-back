using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.ViewModels
{
	public class AuthResponse<T> where T : class
	{
        public string Token { get; set; }
        public T Data { get; set; }
    }
}
