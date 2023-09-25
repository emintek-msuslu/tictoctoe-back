using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Core.Abstract;
using TicTocToe.Model.Core.Concrete;

namespace TicTocToe.Bll.Abstract
{
	public interface IServiceBase<T> where T : class, IBaseEntity
	{
		public Task<ResultModel<T>> GetAsync(Expression<Func<T, bool>> filter);
		public Task<ResultModel<T>> CreateAsync(T entity);
		public Task<ResultModel<T>> UpdateAsync(T entity);
		public Task<ResultModel> DeleteAsync(Guid secretId);
	}
}
