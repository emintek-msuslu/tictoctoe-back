using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TicTocToe.Model.Core.Concrete;
using TicTocToe.Repo.Abstract;

namespace TicTocToe.Repo.Concrete
{
	public class RepositoryAsync<T, TContext> : IRepositoryAsync<T>
		where T : class
		where TContext : DbContext, new()
	{
		readonly protected TContext _context;
		readonly protected DbSet<T> _entitySet;
		public RepositoryAsync(TContext context)
		{
			_context = context;
			_entitySet = _context.Set<T>();
		}
		public async Task<ResultModel<T>> CreateAsync(T entity)
		{
			try
			{
				await _entitySet.AddAsync(entity);
				await _context.SaveChangesAsync();
				return new ResultModel<T> { Data = entity,Message="entity added" ,Success = true, Errors = null} ;
			}
			catch (Exception ex)
			{
				return new ResultModel<T> { Data = null, Errors = new List<string>() { ex.Message }, Success = false, Message = "entity could not be created" };
			}
		}

		public async Task<ResultModel> DeleteAsync(T entity)
		{
			try
			{
				_entitySet.Remove(entity);
				await _context.SaveChangesAsync();
				return new ResultModel() { Errors = null, Success = true, Message = "entity deleted" };
				
			}
			catch (Exception ex)
			{
				return new ResultModel() { Errors = new List<string>() { ex.Message}, Success = true, Message = "entity could not be deleted" };
			}
		}
		public async Task<ResultModel<T>> GetByIdAsync(int id)
		{
			try
			{
			  	T data = await _entitySet.FindAsync(id);
				return new ResultModel<T>() { Data = data, Errors = null, Message = "data fetched", Success = true };
			}
			catch (Exception ex)
			{
				return new ResultModel<T>() { Data = null, Errors = new List<string>() { ex.Message } , Message = "an error occured ", Success = false };
			}
		}

		public async Task<ResultModel<T>> GetOneAsync(Expression<Func<T, bool>> filter = null)
		{
			try
			{
				T data = await _entitySet.FirstOrDefaultAsync(filter);
				return new ResultModel<T>() { Data = data, Errors = null, Message = "data fetched", Success = true };

			}
			catch (Exception ex)
			{
				return new ResultModel<T>() { Data = null, Errors = new List<string>() { ex.Message }, Message = "an error occured ", Success = false };
			}
		}

		public async Task<ResultModel<T>> UpdateAsync(T entity)
		{
			try
			{
				_context.Entry(entity).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return new ResultModel<T>() { Data = entity, Errors = null, Message = "entity updated",Success=true};
			}
			catch (Exception ex)
			{
				return new ResultModel<T> { Data = null, Success = false, Message ="an error occured",Errors = new List<string>() { ex.Message} };
			}
		}
	}
}
