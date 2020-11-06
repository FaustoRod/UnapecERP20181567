using System;

namespace UnapecErpData
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}