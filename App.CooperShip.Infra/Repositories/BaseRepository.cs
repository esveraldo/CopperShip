using App.CooperShip.Domain.Base;
using App.CooperShip.Infra.Interfaces;
using App.CooperShip.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.CooperShip.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task Remove(Guid id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                //_context.Remove(obj);
                _context.Entry(obj).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T?> Get(Guid? id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
