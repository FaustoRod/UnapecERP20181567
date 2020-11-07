using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnapecERPApp.Interfaces
{
    public interface IBaseWebPoster<T>
    {
        Task<bool> Create(T entity);
        Task <bool>Update(T entity);
        Task <bool>Delete(int id);
        Task<T> GetSingle(int id);
        Task<IList<T>> GetAll();
    }
}