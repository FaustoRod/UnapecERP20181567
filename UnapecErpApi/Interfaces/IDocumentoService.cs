using System.Collections.Generic;
using System.Threading.Tasks;
using UnapecErpData.Dto;
using UnapecErpData.Model;
using UnapecErpData.ViewModel;

namespace UnapecErpApi.Interfaces
{
    public interface IDocumentoService:IBaseService<Documento>
    {
        Task<bool> Pagar(int id);
        Task<IList<Documento>> SearchDocumentos(DocumentSearchDto documento);
        Task<IList<DocumentoViewModel>> GetDocumentos();
    }
}