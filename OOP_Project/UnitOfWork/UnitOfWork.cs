using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OOP_Project.Repository;

namespace OOP_Project.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private Dictionary<Type, object> _repositories;

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new EfRepository<T>(_context);
            }

            return (IRepository<T>) _repositories[type];
        }

        public int CompleteWork()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
