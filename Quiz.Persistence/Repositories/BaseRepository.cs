using Quiz.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly QuizDbContext _db;
        public BaseRepository(QuizDbContext db)
        {
            this._db = db;
        }
        public async Task<T> AddAsync(T entity)
        {
             await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public  async Task DeleteAsync(T entity)
        {
             _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
          return  await _db.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIDAsync(int id)
        {
             T? t= await _db.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<IReadOnlyList<T>> GetPagedRespanseAsync(int pageIndex, int pageSize)
        {
            if(pageSize == 0||pageSize==null) { pageSize = 20; }
            if(pageIndex <= 0||pageIndex==null) {  pageIndex = 1; }
            return await _db.Set<T>().Skip((pageIndex-1)*pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State= EntityState.Modified;
           await _db.SaveChangesAsync();
        }
    }
}
