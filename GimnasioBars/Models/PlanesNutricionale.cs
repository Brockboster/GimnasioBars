using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class PlanesNutricionale
    {
        public PlanesNutricionale()
        {
            PlanesNutricionalesUsuarios = new HashSet<PlanesNutricionalesUsuario>();
        }

        public int IdPlanNutricional { get; set; }
        public int IdUsuario { get; set; }
        public string NombrePlan { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<PlanesNutricionalesUsuario> PlanesNutricionalesUsuarios { get; set; }
    }
}
