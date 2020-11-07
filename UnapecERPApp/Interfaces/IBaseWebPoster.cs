using System.Collections.Generic;
using System.Threading.Tasks;
using UnapecErpData.Model;

namespace UnapecERPApp.Interfaces
{
    public interface IBaseWebPoster<T>
    {
        Task<bool> Create(T entity);
        Task <bool>Update(T entity);
        Task <bool>Delete(int id);
        Task<ConceptoPago> GetSingle(int id);
        Task<IList<ConceptoPago>> GetAll();
    }
}