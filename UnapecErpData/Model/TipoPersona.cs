using System.Collections.Generic;

namespace UnapecErpData.Model
{
    public class TipoPersona:BaseMantenimiento
    {
        public virtual IList<Proveedor> Proveedores { get; set; }
    }
}