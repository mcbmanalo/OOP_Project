using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OOP_Project.Repository
{
    public class EfRepository<T> : IRepository<T> where T: class, new()
    {
        private DbContext _context;

        public EfRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            AddRange(new List<T>(){item});
        }

        public void AddRange(ICollection<T> items)
        {
            try
            {
                _context.Set<T>().AddRange(items);
            }
            catch (Exception e)
            {
                throw new RepositoryException<T>(items, "AN ERROR",e);
            }
        }

        public void Remove(T item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public void RemoveRange(ICollection<T> items)
        {
            _context.Set<T>().RemoveRange(items);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Update(ICollection<T> items)
        {
            _context.Set<T>().UpdateRange(items);
        }

        public void Detach(T item)
        {
            _context.Entry(item).State = EntityState.Detached;
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>();
        }
    }
}
