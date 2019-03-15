using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Repository
{
    public class RepositoryException<T> : Exception
    {
        public ICollection<T> ItemsUsed { get; }

        public RepositoryException(ICollection<T> items, string message, Exception e) : base(message , e)
        {
            ItemsUsed = new List<T>(items);
        }

        public RepositoryException(T item, string message, Exception e) : base(message, e)
        {
            ItemsUsed = new List<T>() {item};
        }
    }

}
