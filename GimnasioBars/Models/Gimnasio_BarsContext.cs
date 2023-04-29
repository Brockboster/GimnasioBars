using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GimnasioBars.Models
{
    public partial class Gimnasio_BarsContext : DbContext
    {
        public Gimnasio_BarsContext()
        {
        }

        public Gimnasio_BarsContext(DbContextOptions<Gimnasio_BarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<EjerciciosRutina> EjerciciosRutinas { get; set; } = null!;
        public virtual DbSet<PlanesNutricionale> PlanesNutricionales { get; set; } = null!;
        public virtual DbSet<PlanesNutricionalesUsuario> PlanesNutricionalesUsuarios { get; set; } = null!;
        public virtual DbSet<Rutina> Rutinas { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-ULMSP3L\\MSSQLSERVER02;DATABASE=Gimnasio_Bars;INTEGRATED SECURITY=TRUE;User Id=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.HasKey(e => e.IdEjercicio)
                    .HasName("PK__ejercici__7BB4D9DBE4BF25CF");

                entity.ToTable("ejercicios");

                entity.Property(e => e.IdEjercicio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_ejercicio");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Imagen)
                    .HasColumnType("text")
                    .HasColumnName("imagen");

                entity.Property(e => e.NombreEjercicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_ejercicio");
            });

            modelBuilder.Entity<EjerciciosRutina>(entity =>
            {
                entity.HasKey(e => e.IdEjercicioRutina)
                    .HasName("PK__ejercici__5D00336D4874F5A0");

                entity.ToTable("ejercicios_rutina");

                entity.Property(e => e.IdEjercicioRutina)
                    .ValueGeneratedNever()
                    .HasColumnName("id_ejercicio_rutina");

                entity.Property(e => e.IdEjercicio).HasColumnName("id_ejercicio");

                entity.Property(e => e.IdRutina).HasColumnName("id_rutina");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");

                entity.Property(e => e.Series).HasColumnName("series");

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.EjerciciosRutinas)
                    .HasForeignKey(d => d.IdEjercicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ejercicio__id_ej__4316F928");

                entity.HasOne(d => d.IdRutinaNavigation)
                    .WithMany(p => p.EjerciciosRutinas)
                    .HasForeignKey(d => d.IdRutina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ejercicio__id_ru__4222D4EF");
            });

            modelBuilder.Entity<PlanesNutricionale>(entity =>
            {
                entity.HasKey(e => e.IdPlanNutricional)
                    .HasName("PK__planes_n__EECB1D1F0F6C9687");

                entity.ToTable("planes_nutricionales");

                entity.Property(e => e.IdPlanNutricional)
                    .ValueGeneratedNever()
                    .HasColumnName("id_plan_nutricional");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NombrePlan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_plan");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PlanesNutricionales)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planes_nu__id_us__3A81B327");
            });

            modelBuilder.Entity<PlanesNutricionalesUsuario>(entity =>
            {
                entity.HasKey(e => e.IdPlanNutricionalUsuario)
                    .HasName("PK__planes_n__3635CBAE0FEFD086");

                entity.ToTable("planes_nutricionales_usuarios");

                entity.Property(e => e.IdPlanNutricionalUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("id_plan_nutricional_usuario");

                entity.Property(e => e.IdPlanNutricional).HasColumnName("id_plan_nutricional");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdPlanNutricionalNavigation)
                    .WithMany(p => p.PlanesNutricionalesUsuarios)
                    .HasForeignKey(d => d.IdPlanNutricional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planes_nu__id_pl__46E78A0C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PlanesNutricionalesUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__planes_nu__id_us__45F365D3");
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina)
                    .HasName("PK__rutinas__A2849667879A9ED3");

                entity.ToTable("rutinas");

                entity.Property(e => e.IdRutina)
                    .ValueGeneratedNever()
                    .HasColumnName("id_rutina");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NombreRutina)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_rutina");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Rutinas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rutinas__id_usua__3F466844");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IdUserRole)
                    .HasName("PK__UserRole__4FD2ABB3FC9608E7");

                entity.Property(e => e.IdUserRole)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user_role");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UserRolesNavigation)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__id_us__5441852A");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__UserStat__5D2DC6E8F8D4963D");

                entity.ToTable("UserStatus");

                entity.Property(e => e.IdStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_status");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__4E3E04AD887D5664");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.CorreoElectronico, "UQ__usuarios__5B8A06827D617C45")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.IdUserRole).HasColumnName("id_user_role");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UserRoles)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatusId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserRoleNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdUserRole)
                    .HasConstraintName("fk_id_user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
