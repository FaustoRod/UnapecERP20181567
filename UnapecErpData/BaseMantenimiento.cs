using System.ComponentModel.DataAnnotations;

namespace UnapecErpData
{
    public class BaseMantenimiento:BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}