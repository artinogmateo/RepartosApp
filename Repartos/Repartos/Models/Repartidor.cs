using SQLite;
using System;

namespace Repartos.Models
{
    [Table("Repartidor")]
    public class Repartidor
    {
        [PrimaryKey]
        public int IdRepartidor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}


