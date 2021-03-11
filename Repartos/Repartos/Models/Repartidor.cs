using SQLite;
using System;

namespace Repartos.Models
{
    [Table("Repartidor")]
    public class Repartidor
    {
        private int _IdRepartidor;
        [Column("IdRepartidor")]
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int IdRepartidor
        {
            get { return _IdRepartidor; }
            set
            {
                if (_IdRepartidor != value)
                {
                    _IdRepartidor = value;
                }
            }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Documento { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}


    