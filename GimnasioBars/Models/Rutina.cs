using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class Rutina
    {
        public Rutina()
        {
            EjerciciosRutinas = new HashSet<EjerciciosRutina>();
        }

        public int IdRutina { get; set; }
        public int IdUsuario { get; set; }
        public string NombreRutina { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<EjerciciosRutina> EjerciciosRutinas { get; set; }
    }
}
