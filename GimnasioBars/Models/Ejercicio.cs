using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            EjerciciosRutinas = new HashSet<EjerciciosRutina>();
        }

        public int IdEjercicio { get; set; }
        public string NombreEjercicio { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? Imagen { get; set; }

        public virtual ICollection<EjerciciosRutina> EjerciciosRutinas { get; set; }
    }
}
