using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class LiberiaDriveContext : DbContext
{
    public LiberiaDriveContext()
    {
    }

    public LiberiaDriveContext(DbContextOptions<LiberiaDriveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accion> Accion { get; set; }

    public virtual DbSet<Cita> Cita { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Cliente_Paquete> Cliente_Paquete { get; set; }

    public virtual DbSet<Disponibilidad_Instructor> Disponibilidad_Instructor { get; set; }

    public virtual DbSet<Disponibilidad_Vehiculo> Disponibilidad_Vehiculo { get; set; }

    public virtual DbSet<HistorialCliente> HistorialCliente { get; set; }

    public virtual DbSet<Horario_Instructor> Horario_Instructor { get; set; }

    public virtual DbSet<Horario_Vehiculo> Horario_Vehiculo { get; set; }

    public virtual DbSet<Instructor> Instructor { get; set; }

    public virtual DbSet<Leccion> Leccion { get; set; }

    public virtual DbSet<Mantenimiento_Vehiculo> Mantenimiento_Vehiculo { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<Paquete> Paquete { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Simulacro> Simulacro { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

    public virtual DbSet<vw_Citas> vw_Citas { get; set; }

    public virtual DbSet<vw_Clientes> vw_Clientes { get; set; }

    public virtual DbSet<vw_Lecciones> vw_Lecciones { get; set; }

    public virtual DbSet<vw_Pagos> vw_Pagos { get; set; }

    public virtual DbSet<vw_Simulacros> vw_Simulacros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-TH220SR9\\SQLEXPRESS;Database=LiberiaDriveDB;User Id=sa;Password=12345678;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accion>(entity =>
        {
            entity.HasKey(e => e.ID_Accion).HasName("PK__Accion__7E770C64AABDEB28");

            entity.Property(e => e.descripcion).HasMaxLength(255);
            entity.Property(e => e.fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ID_UsuarioNavigation).WithMany(p => p.Accion)
                .HasForeignKey(d => d.ID_Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accion_Usuario");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.ID_Cita).HasName("PK__Cita__7C17FD160CBD3D94");

            entity.ToTable(tb => tb.HasTrigger("trg_Cita_Update"));

            entity.HasIndex(e => new { e.ID_Cliente, e.fecha }, "IX_Cita_Cliente_Fecha");

            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.observaciones).HasMaxLength(255);
            entity.Property(e => e.tipo).HasMaxLength(50);

            entity.HasOne(d => d.ID_ClienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.ID_Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Cliente");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ID_Cliente).HasName("PK__Cliente__E005FBFFBFFBB9D6");

            entity.ToTable(tb => tb.HasTrigger("trg_Cliente_Delete"));

            entity.Property(e => e.contacto).HasMaxLength(150);
            entity.Property(e => e.fecha_registro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente_Paquete>(entity =>
        {
            entity.HasKey(e => e.ID_ClientePaquete).HasName("PK__Cliente___A4B3411B8CAE69BA");

            entity.HasIndex(e => e.ID_Cliente, "IX_CP_Cliente");

            entity.HasIndex(e => e.ID_Paquete, "IX_CP_Paquete");

            entity.Property(e => e.fecha_contratacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ID_ClienteNavigation).WithMany(p => p.Cliente_Paquete)
                .HasForeignKey(d => d.ID_Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CP_Cliente");

            entity.HasOne(d => d.ID_PaqueteNavigation).WithMany(p => p.Cliente_Paquete)
                .HasForeignKey(d => d.ID_Paquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CP_Paquete");
        });

        modelBuilder.Entity<Disponibilidad_Instructor>(entity =>
        {
            entity.HasKey(e => e.ID_DisponibilidadInstructor).HasName("PK__Disponib__26E238CDAAEC0942");

            entity.HasIndex(e => new { e.ID_Instructor, e.fecha }, "IX_DI_Instructor_Fecha");

            entity.Property(e => e.estado).HasMaxLength(50);

            entity.HasOne(d => d.ID_InstructorNavigation).WithMany(p => p.Disponibilidad_Instructor)
                .HasForeignKey(d => d.ID_Instructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DI_Instructor");
        });

        modelBuilder.Entity<Disponibilidad_Vehiculo>(entity =>
        {
            entity.HasKey(e => e.ID_DisponibilidadVehiculo).HasName("PK__Disponib__4F922EBE99F9AD8C");

            entity.HasIndex(e => new { e.ID_Vehiculo, e.fecha }, "IX_DV_Vehiculo_Fecha");

            entity.Property(e => e.estado).HasMaxLength(50);

            entity.HasOne(d => d.ID_VehiculoNavigation).WithMany(p => p.Disponibilidad_Vehiculo)
                .HasForeignKey(d => d.ID_Vehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DV_Vehiculo");
        });

        modelBuilder.Entity<HistorialCliente>(entity =>
        {
            entity.HasKey(e => e.ID_Historial).HasName("PK__Historia__ECA894543471E9A5");

            entity.HasIndex(e => e.ID_Cliente, "UQ__Historia__E005FBFEC44539DE").IsUnique();

            entity.Property(e => e.estado_actual).HasMaxLength(50);

            entity.HasOne(d => d.ID_ClienteNavigation).WithOne(p => p.HistorialCliente)
                .HasForeignKey<HistorialCliente>(d => d.ID_Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Cliente");
        });

        modelBuilder.Entity<Horario_Instructor>(entity =>
        {
            entity.HasKey(e => e.ID_HorarioInstructor).HasName("PK__Horario___84ACB0B0C609EB31");

            entity.HasIndex(e => e.ID_Instructor, "IX_HI_Instructor");

            entity.Property(e => e.dia_semana).HasMaxLength(20);

            entity.HasOne(d => d.ID_InstructorNavigation).WithMany(p => p.Horario_Instructor)
                .HasForeignKey(d => d.ID_Instructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HI_Instructor");
        });

        modelBuilder.Entity<Horario_Vehiculo>(entity =>
        {
            entity.HasKey(e => e.ID_HorarioVehiculo).HasName("PK__Horario___83653B3540F3A47B");

            entity.Property(e => e.dia_semana).HasMaxLength(20);

            entity.HasOne(d => d.ID_VehiculoNavigation).WithMany(p => p.Horario_Vehiculo)
                .HasForeignKey(d => d.ID_Vehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HV_Vehiculo");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.ID_Instructor).HasName("PK__Instruct__F06DA14019BFD90B");

            entity.Property(e => e.licencia).HasMaxLength(50);
            entity.Property(e => e.nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Leccion>(entity =>
        {
            entity.HasKey(e => e.ID_Leccion).HasName("PK__Leccion__B3509510088BF199");

            entity.ToTable(tb => tb.HasTrigger("trg_Leccion_Insert"));

            entity.HasIndex(e => new { e.fecha, e.ID_Instructor, e.ID_Vehiculo }, "IX_Leccion_Fechas");

            entity.Property(e => e.calificacion).HasMaxLength(50);
            entity.Property(e => e.tipo).HasMaxLength(50);

            entity.HasOne(d => d.ID_ClienteNavigation).WithMany(p => p.Leccion)
                .HasForeignKey(d => d.ID_Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lec_Cliente");

            entity.HasOne(d => d.ID_InstructorNavigation).WithMany(p => p.Leccion)
                .HasForeignKey(d => d.ID_Instructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lec_Instr");

            entity.HasOne(d => d.ID_VehiculoNavigation).WithMany(p => p.Leccion)
                .HasForeignKey(d => d.ID_Vehiculo)
                .HasConstraintName("FK_Lec_Veh");
        });

        modelBuilder.Entity<Mantenimiento_Vehiculo>(entity =>
        {
            entity.HasKey(e => e.ID_Mantenimiento).HasName("PK__Mantenim__BD4C405A06816D78");

            entity.ToTable(tb => tb.HasTrigger("trg_Mantenimiento_Insert"));

            entity.HasIndex(e => new { e.ID_Vehiculo, e.fecha }, "IX_Mant_Vehiculo_Fecha");

            entity.Property(e => e.costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.tipo).HasMaxLength(50);

            entity.HasOne(d => d.ID_VehiculoNavigation).WithMany(p => p.Mantenimiento_Vehiculo)
                .HasForeignKey(d => d.ID_Vehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mant_Vehiculo");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.ID_Pago).HasName("PK__Pago__AE88B4290A8A1297");

            entity.ToTable(tb => tb.HasTrigger("trg_Pago_Insert"));

            entity.HasIndex(e => e.ID_ClientePaquete, "IX_Pago_CP");

            entity.Property(e => e.estado).HasMaxLength(30);
            entity.Property(e => e.fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.metodo).HasMaxLength(50);
            entity.Property(e => e.monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ID_ClientePaqueteNavigation).WithMany(p => p.Pago)
                .HasForeignKey(d => d.ID_ClientePaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_CP");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.ID_Paquete).HasName("PK__Paquete__BCBF057BEAA2627D");

            entity.Property(e => e.descripcion).HasMaxLength(255);
            entity.Property(e => e.nombre).HasMaxLength(100);
            entity.Property(e => e.precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.ID_Rol).HasName("PK__Rol__202AD220A9C32624");

            entity.Property(e => e.nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Simulacro>(entity =>
        {
            entity.HasKey(e => e.ID_Simulacro).HasName("PK__Simulacr__C47539F4EC78BDE6");

            entity.HasIndex(e => new { e.fecha, e.ID_Instructor, e.ID_Vehiculo }, "IX_Simulacro_Fechas");

            entity.Property(e => e.resultado).HasMaxLength(50);
            entity.Property(e => e.tipo).HasMaxLength(50);

            entity.HasOne(d => d.ID_ClienteNavigation).WithMany(p => p.Simulacro)
                .HasForeignKey(d => d.ID_Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sim_Cliente");

            entity.HasOne(d => d.ID_InstructorNavigation).WithMany(p => p.Simulacro)
                .HasForeignKey(d => d.ID_Instructor)
                .HasConstraintName("FK_Sim_Instr");

            entity.HasOne(d => d.ID_VehiculoNavigation).WithMany(p => p.Simulacro)
                .HasForeignKey(d => d.ID_Vehiculo)
                .HasConstraintName("FK_Sim_Veh");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.ID_Usuario).HasName("PK__Usuario__DE4431C5662966B9");

            entity.HasIndex(e => e.correo, "UQ__Usuario__2A586E0B0CC01D01").IsUnique();

            entity.Property(e => e.correo).HasMaxLength(100);
            entity.Property(e => e.nombre).HasMaxLength(100);

            entity.HasOne(d => d.ID_RolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.ID_Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.ID_Vehiculo).HasName("PK__Vehiculo__FEFD7E33DFEA336D");

            entity.HasIndex(e => e.placa, "UQ__Vehiculo__0C0574251987016A").IsUnique();

            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.placa).HasMaxLength(20);
            entity.Property(e => e.tipo).HasMaxLength(50);
            entity.Property(e => e.transmision).HasMaxLength(50);
        });

        modelBuilder.Entity<vw_Citas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Citas");

            entity.Property(e => e.ID_Cita).ValueGeneratedOnAdd();
            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<vw_Clientes>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Clientes");

            entity.Property(e => e.ID_Cliente).ValueGeneratedOnAdd();
            entity.Property(e => e.nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<vw_Lecciones>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Lecciones");

            entity.Property(e => e.ID_Leccion).ValueGeneratedOnAdd();
            entity.Property(e => e.tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<vw_Pagos>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Pagos");

            entity.Property(e => e.monto).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<vw_Simulacros>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Simulacros");

            entity.Property(e => e.ID_Simulacro).ValueGeneratedOnAdd();
            entity.Property(e => e.resultado).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
