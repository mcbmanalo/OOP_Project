using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);
        void AddRange(ICollection<T> items);
        void Remove(T item);
        void RemoveRange(ICollection<T> items);
        void Update(T item);
        void Update(ICollection<T> items);
        void Detach(T item);

        IQueryable<T> All();
    }
}
