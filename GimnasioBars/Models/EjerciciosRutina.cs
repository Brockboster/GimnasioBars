using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class EjerciciosRutina
    {
        public int IdEjercicioRutina { get; set; }
        public int IdRutina { get; set; }
        public int IdEjercicio { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public int Peso { get; set; }

        public virtual Ejercicio IdEjercicioNavigation { get; set; } = null!;
        public virtual Rutina IdRutinaNavigation { get; set; } = null!;
    }
}
