namespace GimnasioBars.ModelsDTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string? UserRoles { get; set; }
        public string? UserStatusId { get; set; }
        public int? UserId { get; set; }
        public int? IdUserRole { get; set; }



    }
}
