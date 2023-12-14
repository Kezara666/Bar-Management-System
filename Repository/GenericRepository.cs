﻿using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repos.IRepository;
using System.Linq.Expressions;
namespace Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BMSContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(BMSContext context)
        {
            _context = context;

            _db = _context.Set<T>();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<string> includes)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public Task GetAll(string includes)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetPaginagedResult(IList<T> source, PaginationParams paginationParams)
        {
            return source.Skip((paginationParams.Page - 1) * paginationParams.ItemsPerPage).Take(paginationParams.ItemsPerPage).ToList();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _db.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            T entity = _db.Find(id);
            Delete(entity);
        }





    }
}
