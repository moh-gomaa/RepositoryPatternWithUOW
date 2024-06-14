using RepositoryPatternWithUOW.Core.Consts;
using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string[] includes = null, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        Task<T> GetByIdAsync(int id);
        Task<T> FindFirstAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending,
            bool withPagination = false, int? skip = null, int? take = null);
    }
}
