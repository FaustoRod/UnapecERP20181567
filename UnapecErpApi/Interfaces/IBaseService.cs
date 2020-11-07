using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnapecErpApi.Interfaces
{
    public interface IBaseService<T>
    {
        Task<bool> Save(T entity);
        Task<bool> Update(T entity);
        Task<IList<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<bool> Delete(int id);
    }
}