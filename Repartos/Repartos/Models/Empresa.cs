using SQLite;
using System;

namespace Repartos.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        private int _IdEmpresa;
        [Column("IdEmpresa")]
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set
            {
                if (_IdEmpresa != value)
                {
                    _IdEmpresa = value;
                }
            }
        }
        public string Nombre { get; set; }
        public long CUIT { get; set; }
        public string DireccionRetiroFolletos { get; set; }
        public string DireccionDeCobro { get; set; }
        public string TelefonoPrimario { get; set; }
        public string TelefonoSecundario { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
