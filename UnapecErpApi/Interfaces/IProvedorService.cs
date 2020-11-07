using System.Collections.Generic;
using System.Threading.Tasks;
using UnapecErpData.Dto;
using UnapecErpData.Model;

namespace UnapecErpApi.Interfaces
{
    public interface IProvedorService:IBaseService<Proveedor>
    {
        Task<IList<Proveedor>> SearchProveedor(ProvedorSearchDto provedorSearchDto);
    }
}