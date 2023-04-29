using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class PlanesNutricionalesUsuario
    {
        public int IdPlanNutricionalUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPlanNutricional { get; set; }

        public virtual PlanesNutricionale IdPlanNutricionalNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
