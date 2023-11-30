using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BaseDAO<T, Tkey> : IBaseDAO<T, Tkey> where T : class
    {
        private readonly BirdFarmShop2Context _context;
        private readonly DbSet<T> dbSet;
        public BaseDAO()
        {
            _context = new BirdFarmShop2Context();
            dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var result = dbSet.Where(where);

            foreach (var include in includes)
            {
                result = result.Include(include);
            }
            return result;
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public async Task<T> GetByID(Tkey id)
        {
            return await dbSet.FindAsync(id) ?? throw new Exception();
        }

        public async Task<bool> Remove(Tkey id)
        {
            T? entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            dbSet.Remove(entity);
            return true;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
