using System;
using System.ComponentModel.DataAnnotations;

namespace UnapecErpData
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}