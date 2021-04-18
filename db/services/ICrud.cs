using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace db.services
{
    public interface ICrud<T>
    {
        Task<T> Create(T entity);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<bool> Delete(int id);
        Task<T> Update(int id, T entity);
    }
}
