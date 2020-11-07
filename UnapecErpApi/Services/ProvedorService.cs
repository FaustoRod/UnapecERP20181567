using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnapecErpApi.Context;
using UnapecErpApi.Interfaces;
using UnapecErpData.Dto;
using UnapecErpData.Model;

namespace UnapecErpApi.Services
{
    public class ProvedorService : IProvedorService
    {
        private readonly ErpDbContext _context;

        public ProvedorService(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(Proveedor entity)
        {
            if (entity == null) return false;
            entity.FechaCreacion = entity.FechaModificacion = DateTime.Now;
            entity.Activo = true;
            entity.Balance = 0;
            _context.Proveedores.Add(entity);
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception e)
            {
                var problem = e.InnerException;
                return false;
            }
        }

        public async Task<bool> Update(Proveedor entity)
        {
            if (entity == null) return false;
            var modelUpdate = await GetSingle(entity.Id);
            if (modelUpdate == null) return false;
            modelUpdate.Balance = entity.Balance;
            modelUpdate.Documento = entity.Documento;
            modelUpdate.Nombre = entity.Nombre;
            modelUpdate.TipoPersonaId = entity.TipoPersonaId;
            modelUpdate.Activo = entity.Activo;
            modelUpdate.FechaModificacion = DateTime.Now;
            _context.Proveedores.Update(modelUpdate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IList<Proveedor>> GetAll()
        {
            try
            {
                var list = await _context.Proveedores.Include(x => x.TipoPersona).Where(x => x.Activo).ToListAsync();
                //var list = await _context.Proveedores.Include(x => x.TipoPersona).Where(x => x.Activo).ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public async Task<Proveedor> GetSingle(int id) => await _context.Proveedores.Include(x => x.TipoPersona).Where(x => x.Activo && x.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task<bool> Delete(int id)
        {
            var entity = await GetSingle(id);
            if (entity == null) return false;
            entity.Activo = false;
            return await Update(entity);
        }

        public async Task<IList<Proveedor>> SearchProveedor(ProvedorSearchDto provedorSearchDto)
        {
            var list = await _context.Proveedores.Include(x => x.TipoPersona).Where(x => x.Activo 
                                                                                         && ((!string.IsNullOrEmpty(provedorSearchDto.Nombre) && x.Nombre.Contains(provedorSearchDto.Nombre))
                                                                                         || (!string.IsNullOrEmpty(provedorSearchDto.Documento) && x.Documento.Equals(provedorSearchDto.Documento)))
                                                                                         && x.TipoPersonaId.Equals(provedorSearchDto.TipoId)).ToListAsync();
            return list;
        }
    }
}