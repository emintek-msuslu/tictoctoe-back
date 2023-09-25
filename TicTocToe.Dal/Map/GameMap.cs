using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Entities;

namespace TicTocToe.Dal.Map
{
	public class GameMap : BaseMap<Game>
	{
		public override void Configure(EntityTypeBuilder<Game> builder)
		{
			base.Configure(builder);
		}
	}
}
