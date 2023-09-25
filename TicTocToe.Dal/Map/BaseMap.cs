using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTocToe.Model.Core.Abstract;

namespace TicTocToe.Dal.Map
{
	public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
		where TEntity : class, IBaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(x => x.Id);
		}
	}
}
