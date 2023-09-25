using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Dal.Map;
using TicTocToe.Model.Entities;

namespace TicTocToe.Dal.Contexts
{
	public class TicTocToeDbContext : DbContext
	{
		
		public TicTocToeDbContext()
		{
		}
		public TicTocToeDbContext(DbContextOptions<TicTocToeDbContext> options)
			: base(options)
		{
			
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("Data Source = C:\\Users\\a\\databases\\tictoctoe.db");
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new GameMap());

		}
		public DbSet<Game> Games { get; set; }
	}
}
