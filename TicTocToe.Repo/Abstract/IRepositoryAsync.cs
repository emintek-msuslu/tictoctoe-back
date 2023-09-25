using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicTocToe.Model.Core.Concrete;

namespace TicTocToe.Repo.Abstract
{
	public interface IRepositoryAsync<T>
	{
		Task<ResultModel<T>> GetByIdAsync(int id);
		Task<ResultModel<T>> CreateAsync(T entity);
		Task<ResultModel<T>> UpdateAsync(T entity);
		Task<ResultModel> DeleteAsync(T entity);
		Task<ResultModel<T>> GetOneAsync(Expression<Func<T, bool>> filter = null);
	}
}
