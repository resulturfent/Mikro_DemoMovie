

using DemoMovie.Core.Services;
using DemoMovie.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace DemoMovie.Repository.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        protected readonly AppDbContext _context;
        //private readonly DbSet<T> _dbSet;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }     

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
