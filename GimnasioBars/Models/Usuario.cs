using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            PlanesNutricionales = new HashSet<PlanesNutricionale>();
            PlanesNutricionalesUsuarios = new HashSet<PlanesNutricionalesUsuario>();
            Rutinas = new HashSet<Rutina>();
            UserRolesNavigation = new HashSet<UserRole>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string? UserRoles { get; set; }
        public string? UserStatusId { get; set; }
        public int? UserId { get; set; }
        public int? IdUserRole { get; set; }

        public virtual UserRole? IdUserRoleNavigation { get; set; }
        public virtual ICollection<PlanesNutricionale> PlanesNutricionales { get; set; }
        public virtual ICollection<PlanesNutricionalesUsuario> PlanesNutricionalesUsuarios { get; set; }
        public virtual ICollection<Rutina> Rutinas { get; set; }
        public virtual ICollection<UserRole> UserRolesNavigation { get; set; }
    }
}
