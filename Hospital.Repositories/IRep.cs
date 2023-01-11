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
        T Get(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
        void Save();
    }
}