using System.Collections.Generic;

namespace UnapecErpData.Model
{
    public class Proveedor:BaseModel
    {
        public string Nombre { get; set; }
        public int TipoPersonaId { get; set; }
        public string Documento { get; set; }
        public decimal Balance { get; set; }
        public bool Activo { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}