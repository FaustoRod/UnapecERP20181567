using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnapecErpData.Model
{
    public class Proveedor:BaseModel
    {
        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }
        public int TipoPersonaId { get; set; }
        [Required]
        [MaxLength(11)]
        public string Documento { get; set; }
        public decimal Balance { get; set; }
        public bool Activo { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}