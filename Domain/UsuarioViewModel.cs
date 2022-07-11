using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public ETipoDocumento? TipoDocumento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Por favor ingreser un valor valido")]
        public double? ValorAGanar { get; set; }
        public EEstadoCivil? EstadoCivil { get; set; }
    }
}
