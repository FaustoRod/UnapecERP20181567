using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpApi.Context;
using UnapecErpApi.Interfaces;
using UnapecErpData.Dto;
using UnapecErpData.Model;
using UnapecErpData.ViewModel;
using EstadoDocumento = UnapecErpData.Enums.EstadoDocumento;

namespace UnapecErpApi.Services
{
    public class DocumentoService : IDocumentoService
    {
        private readonly ErpDbContext _context;
        private readonly IProvedorService _provedorService;

        public DocumentoService(ErpDbContext context, IProvedorService provedorService)
        {
            _context = context;
            _provedorService = provedorService;
        }

        public async Task<bool> Save(Documento entity)
        {
            if (entity == null) return false;
            entity.EstadoDocumentoId = (int)EstadoDocumento.Pendiente;
            entity.FechaCreacion = entity.FechaModificacion = DateTime.Now;
            _context.Documentos.Add(entity);
            try
            {
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    var provedor = await _provedorService.GetSingle(entity.ProveedorId);
                    if (provedor != null)
                    {
                        provedor.Balance += entity.Monto;
                        return await _provedorService.Update(provedor);
                    }
                }
                return result > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Update(Documento entity)
        {
            if (entity == null) return false;
            var modelUpdate = await GetSingle(entity.Id);
            if (modelUpdate == null) return false;
            modelUpdate.EstadoDocumentoId = entity.EstadoDocumentoId;
            modelUpdate.Monto = entity.Monto;
            modelUpdate.Numero = entity.Numero;
            modelUpdate.Fecha = entity.Fecha;
            modelUpdate.NumeroFactura = entity.NumeroFactura;
            //modelUpdate.ProveedorId = entity.ProveedorId;
            modelUpdate.FechaModificacion = DateTime.Now;
            _context.Documentos.Update(modelUpdate);
            //return await _context.SaveChangesAsync() > 0;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IList<Documento>> GetAll() => await _context.Documentos.Include(x => x.Proveedor).ToListAsync();

        public async Task<Documento> GetSingle(int id) => await _context.Documentos.Include(x => x.Proveedor).SingleOrDefaultAsync(x => x.Id.Equals(id));

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Pagar(int id)
        {
            var documento = await GetSingle(id);
            if (documento == null) return false;
            documento.EstadoDocumentoId = (int)EstadoDocumento.Pagado;
            var result = await Update(documento);
            if (result)
            {
                var provedor = await _provedorService.GetSingle(documento.ProveedorId);
                if (provedor != null)
                {
                    provedor.Balance -= documento.Monto;
                    return await _provedorService.Update(provedor);
                }
            }
            return result;
        }

        public async Task<IList<Documento>> SearchDocumentos(DocumentSearchDto documento)
        {
            if (documento == null) return new List<Documento>();
            if (!string.IsNullOrEmpty(documento.Numero))
            {
                return await _context.Documentos.Where(x => x.Numero.Contains(documento.Numero)).ToListAsync();
            }

            if (!string.IsNullOrEmpty(documento.NumeroFactura))
            {
                return await _context.Documentos.Where(x => x.NumeroFactura.Contains(documento.NumeroFactura)).ToListAsync();
            }

            if (documento.ProveedorId > 0)
            {
                return await _context.Documentos.Where(x => x.ProveedorId.Equals(documento.ProveedorId)).ToListAsync();
            }

            return await _context.Documentos.Where(x => documento.EstadoDocumentoId == (int)EstadoDocumento.Todos || x.EstadoDocumentoId.Equals(documento.EstadoDocumentoId)).ToListAsync();

        }

        public async Task<IList<DocumentoViewModel>> SearchDocumentosNew(DocumentSearchDto documento)
        {
            if (documento == null) return null;
            if (!string.IsNullOrEmpty(documento.Numero))
            {
                return GetDocumentoViewModel(await _context.Documentos.Include(x => x.Proveedor).Where(x => (documento.EstadoDocumentoId.Equals((EstadoDocumento.Todos)) || x.EstadoDocumentoId.Equals(documento.EstadoDocumentoId))
                                                                                 && x.Numero.Contains(documento.Numero)).ToListAsync());
            }

            if (!string.IsNullOrEmpty(documento.NumeroFactura))
            {
                return GetDocumentoViewModel(await _context.Documentos.Include(x => x.Proveedor).Where(x => (documento.EstadoDocumentoId.Equals((EstadoDocumento.Todos)) || x.EstadoDocumentoId.Equals(documento.EstadoDocumentoId))
                                                                                                            && x.NumeroFactura.Contains(documento.NumeroFactura)).ToListAsync());
            }

            var isTodos = documento.EstadoDocumentoId.Equals((int)EstadoDocumento.Todos);
            //return GetDocumentoViewModel(await _context.Documentos.Include(x => x.Proveedor).Where(x => x.Fecha >= documento.FechaDesde.Date && x.Fecha.Date <= documento.FechaHasta.Date).ToListAsync());
            return GetDocumentoViewModel(await _context.Documentos.Include(x => x.Proveedor).Where(x =>
                (isTodos ||
                 x.EstadoDocumentoId.Equals(documento.EstadoDocumentoId)) && x.Fecha >= documento.FechaDesde.Date && x.Fecha.Date <= documento.FechaHasta.Date).ToListAsync());
        }

        public async Task<IList<DocumentoViewModel>> GetDocumentos()
        {
            var list = await GetAll();

            return GetDocumentoViewModel(list);
        }

        public IList<DocumentoViewModel> GetDocumentoViewModel(IList<Documento> documentos)
        {
            if (documentos == null || !documentos.Any()) return new List<DocumentoViewModel>();
            return (from d in documentos
                    select new DocumentoViewModel
                    {
                        Proveedor = d.Proveedor.Nombre,
                        Numero = d.Numero,
                        Factura = d.NumeroFactura,
                        Monto = d.Monto,
                        Estado = ((EstadoDocumento)d.EstadoDocumentoId).ToString(),
                        Fecha = d.Fecha.ToString("d"),
                        Id = d.Id,
                        EstadoId = d.EstadoDocumentoId
                    }).ToList();
        }
    }
}