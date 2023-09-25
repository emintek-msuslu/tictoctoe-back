using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Bll.Abstract;
using TicTocToe.Model.Core.Abstract;
using TicTocToe.Model.Core.Concrete;
using TicTocToe.Repo.Abstract;

namespace TicTocToe.Bll.Concrete
{
	public class GenericManager<T, TIDal> : IServiceBase<T> where T : class, IBaseEntity where TIDal : IRepositoryAsync<T>
	{
		readonly protected TIDal _dal;
		readonly protected ILogger _logger;
		public GenericManager(TIDal dal)
		{
			_dal = dal;
		}

		public async Task<ResultModel> DeleteAsync(Guid secretId)
		{

			ResultModel<T> item = await _dal.GetOneAsync(x => x.SecretId == secretId);
			ResultModel result = await _dal.DeleteAsync(item.Data);
			return result;

		}

		public async Task<ResultModel<T>> GetAsync(Expression<Func<T, bool>> filter)
		{
			ResultModel<T> item = await _dal.GetOneAsync(filter);
			return item;
		}

		public async Task<ResultModel<T>> CreateAsync(T entity)
		{
			ResultModel<T> item = await _dal.CreateAsync(entity);
			return item;
		}

		public async Task<ResultModel<T>> UpdateAsync(T entity)
		{
			ResultModel<T> item = await _dal.UpdateAsync(entity);
			return item;
		}
	}
}
