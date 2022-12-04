using System.Linq.Expressions;

namespace DemoMovie.Core.Services
{
    public interface IService<T> where T : class
    {
        //Dönüş tiplerinde Repository den farklı olacak
        Task<T> GetByIdAsync(int Id);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

    }
}
