using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public ETipoDocumento? TipoDocumento { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public double? ValorAGanar { get; set; }
        public EEstadoCivil? EstadoCivil { get; set; }
    }
}
