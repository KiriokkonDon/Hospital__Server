using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface IRep<T> where T : class
    {
        IEnumerable<T> GetAll();
        bool Create(T item);
        bool Update(T item);
        bool Delete(T item);
        void Save();
    }
}