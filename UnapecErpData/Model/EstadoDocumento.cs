using System.Collections.Generic;

namespace UnapecErpData.Model
{
    public class EstadoDocumento:BaseMantenimiento
    {
        public virtual IList<Documento> Documento { get; set; }
    }
}