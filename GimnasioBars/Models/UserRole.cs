using System;
using System.Collections.Generic;

namespace GimnasioBars.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdUserRole { get; set; }
        public int IdUsuario { get; set; }
        public string Role { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
