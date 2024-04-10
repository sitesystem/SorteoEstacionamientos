using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

public partial class DBSorteoParkingContext : DbContext
{
    public DBSorteoParkingContext()
    {
    }

    public DBSorteoParkingContext(DbContextOptions<DBSorteoParkingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<McCatCarrera> McCatCarreras { get; set; }

    public virtual DbSet<McCatColore> McCatColores { get; set; }

    public virtual DbSet<McCatEscuela> McCatEscuelas { get; set; }

    public virtual DbSet<McCatEstadosRepMexicana> McCatEstadosRepMexicanas { get; set; }

    public virtual DbSet<McCatLink> McCatLinks { get; set; }

    public virtual DbSet<McCatRole> McCatRoles { get; set; }

    public virtual DbSet<McCatSemestre> McCatSemestres { get; set; }

    public virtual DbSet<McCatTipoParticipante> McCatTipoParticipantes { get; set; }

    public virtual DbSet<McCatTipoPlaca> McCatTipoPlacas { get; set; }

    public virtual DbSet<McCatTipoVehiculo> McCatTipoVehiculos { get; set; }

    public virtual DbSet<MsCatPeriodoRegistro> MsCatPeriodoRegistros { get; set; }

    public virtual DbSet<MsTbGanadore> MsTbGanadores { get; set; }

    public virtual DbSet<MsTbParticipante> MsTbParticipantes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=148.204.211.186;port=3306;database=db_SorteoEstacionamientos;user id=root;password=123123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<McCatCarrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PRIMARY");

            entity.Property(e => e.IdCarrera).HasComment("PK ID Único de la Carrera / Licenciatura");
            entity.Property(e => e.CarrClave)
                .HasDefaultValueSql("'-'")
                .HasComment("Clave de la Carrera / Licenciatura");
            entity.Property(e => e.CarrNombre).HasComment("Nombre de la Carrera / Licenciatura");
            entity.Property(e => e.CarrStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("Estado (1 = Activo, 0 = Inactivo)");
        });

        modelBuilder.Entity<McCatColore>(entity =>
        {
            entity.HasKey(e => e.IdColor).HasName("PRIMARY");

            entity.Property(e => e.IdColor).HasComment("PK ID Único del Color");
            entity.Property(e => e.ColorNombre).HasComment("Nombre del Color");
        });

        modelBuilder.Entity<McCatEscuela>(entity =>
        {
            entity.HasKey(e => e.IdEscuela).HasName("PRIMARY");

            entity.Property(e => e.IdEscuela).HasComment("PK ID Único de la Escuela");
            entity.Property(e => e.EscFechaFundacion).HasComment("Fecha de Fundación de la Escuela");
            entity.Property(e => e.EscFileNameAvisoPrivacidad).HasComment("Nombre del Archivo del Aviso de Privacidad");
            entity.Property(e => e.EscLogo).HasComment("Nombre de la Imágen del Logo");
            entity.Property(e => e.EscNoEscuela)
                .HasDefaultValueSql("'-'")
                .HasComment("Número de la Escuela");
            entity.Property(e => e.EscNombreCorto).HasComment("Nombre Corto de la Escuela");
            entity.Property(e => e.EscNombreLargo).HasComment("Nombre Largo de la Escuela");
            entity.Property(e => e.EscStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("Estado (1 = Activo, 0 = Inactivo)");
        });

        modelBuilder.Entity<McCatEstadosRepMexicana>(entity =>
        {
            entity.HasKey(e => e.IdEdoRepMex).HasName("PRIMARY");

            entity.Property(e => e.IdEdoRepMex).HasComment("PK ID Único del Estado de la República Mexicana");
            entity.Property(e => e.EdoNombre).HasComment("Estado de la República Mexicana (32 Estados)");
        });

        modelBuilder.Entity<McCatLink>(entity =>
        {
            entity.HasKey(e => e.IdLink).HasName("PRIMARY");

            entity.Property(e => e.IdLink).HasComment("PK ID Único del Enlace Link");
            entity.Property(e => e.LinkEnlace).HasComment("Enlace o Link");
            entity.Property(e => e.LinkNombre).HasComment("Nombre del Enlace o Link");
            entity.Property(e => e.LinkStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("Estado (1 = Activo, 0 = Inactivo)");
        });

        modelBuilder.Entity<McCatRole>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.Property(e => e.IdRol).HasComment("PK ID Único del Rol");
            entity.Property(e => e.RolDescripcion).HasComment("Descripción detallada del Rol");
            entity.Property(e => e.RolNombre).HasComment("Nombre del Rol");
        });

        modelBuilder.Entity<McCatSemestre>(entity =>
        {
            entity.HasKey(e => e.IdSemestre).HasName("PRIMARY");

            entity.Property(e => e.IdSemestre).HasComment("PK ID Único del Semestre");
            entity.Property(e => e.NumSemestre).HasComment("Número de Semestre");
        });

        modelBuilder.Entity<McCatTipoParticipante>(entity =>
        {
            entity.HasKey(e => e.IdTipoParticipante).HasName("PRIMARY");

            entity.Property(e => e.IdTipoParticipante).HasComment("PK ID Único del Tipo de Participante");
            entity.Property(e => e.TipopartNombre).HasComment("Nombre / Descripción del Tipo de Participante");
            entity.Property(e => e.TipopartStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("Status { 0 - Inactivo, 1 - Activo }");
        });

        modelBuilder.Entity<McCatTipoPlaca>(entity =>
        {
            entity.HasKey(e => e.IdTipoPlaca).HasName("PRIMARY");

            entity.Property(e => e.IdTipoPlaca).HasComment("PK ID Único del Tipo de Placa");
            entity.Property(e => e.TipoPlaca).HasComment("Tipo de la Placa { Antiguo/Clásico, Capacidades diferentes, Particular, Público (Taxi, Uber) }");
        });

        modelBuilder.Entity<McCatTipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipoVehiculo).HasName("PRIMARY");

            entity.Property(e => e.IdTipoVehiculo).HasComment("PK ID Único del Tipo de Vehículo { 1 - Auto, 2 - Moto }");
            entity.Property(e => e.TipoVehiculo).HasComment("Nombre del Tipo de Vehículo");
        });

        modelBuilder.Entity<MsCatPeriodoRegistro>(entity =>
        {
            entity.HasKey(e => e.IdPeriodoRegistro).HasName("PRIMARY");

            entity.Property(e => e.IdPeriodoRegistro).HasComment("PK ID Único del Período de Registro (Calendarización)");
            entity.Property(e => e.PerFechaHoraFin).HasComment("Fecha y Hora de Fin de Apertura de Registro para el Sorteo");
            entity.Property(e => e.PerFechaHoraInicio).HasComment("Fecha y Hora de Inicio de Apertura de Registro para el Sorteo");
            entity.Property(e => e.PerFileNameConvocatoria).HasComment("Nombre del Archivo de la Convocatoria del Período para el Sorteo de Autos y Motos");
            entity.Property(e => e.PerStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("Estado del Periodo / Calendario de Registro para el Sorteo { 0 - Inactivo, 1 - Activo }");
        });

        modelBuilder.Entity<MsTbGanadore>(entity =>
        {
            entity.HasKey(e => e.IdGanador).HasName("PRIMARY");

            entity.Property(e => e.IdGanador).HasComment("PK ID Único del Ganador");
            entity.Property(e => e.WinFechaHoraSorteo)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Fecha y Hora del Sorteo para Corbatines de Estacionamientos");
            entity.Property(e => e.WinIdParticipante)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID del Participante");

            entity.HasOne(d => d.WinIdParticipanteNavigation).WithMany(p => p.MsTbGanadores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdParticipante");
        });

        modelBuilder.Entity<MsTbParticipante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PRIMARY");

            entity.Property(e => e.IdParticipante).HasComment("PK ID Único del Participante");
            entity.Property(e => e.PartAño).HasComment("Año del Vehículo");
            entity.Property(e => e.PartBoleta).HasComment("Número de Boleta en caso de ser Alumno");
            entity.Property(e => e.PartColor).HasComment("Color del Vehículo");
            entity.Property(e => e.PartContraseña).HasComment("Contraseña para el acceso a la Plataforma SSOE");
            entity.Property(e => e.PartCurp)
                .HasDefaultValueSql("'-'")
                .HasComment("CURP del Participante de 18 caracteres");
            entity.Property(e => e.PartEmail).HasComment("Correo Electrónico Institucional / Personal");
            entity.Property(e => e.PartFechaHoraAlta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Fecha y Hora del alta del registro");
            entity.Property(e => e.PartFileNameComprobanteEstudiosHorario)
                .HasDefaultValueSql("'-'")
                .HasComment("Nombre del Archivo del Comprobante de Estudios / Horario (Tira de Materias)");
            entity.Property(e => e.PartFileNameCredencialIpnine)
                .HasDefaultValueSql("'-'")
                .HasComment("Nombre del Archivo de la Credencial Oficial del IPN / INE");
            entity.Property(e => e.PartFileNameLicenciaConducir)
                .HasDefaultValueSql("'-'")
                .HasComment("Nombre del Archivo de la Licencia de Conducir");
            entity.Property(e => e.PartFileNameTarjetaCirculacion)
                .HasDefaultValueSql("'-'")
                .HasComment("Nombre del Archivo de la Tarjeta de Circulación");
            entity.Property(e => e.PartIdCarrera)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID de la Carrera / Licenciatura");
            entity.Property(e => e.PartIdEdoRepMexVehiculo)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID del Estado de la República Mexicana");
            entity.Property(e => e.PartIdRol)
                .HasDefaultValueSql("'2'")
                .HasComment("FK ID del Rol del Participante { 1 - Administrador, 2 - Usuario Participante }");
            entity.Property(e => e.PartIdSemestre)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID del Último Semestre Cursado { 1 - 10 }");
            entity.Property(e => e.PartIdTipoParticipante)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID del Tipo de Participante { 1 - Nuevo Ingreso (Pre-Boleta), 2 - Inscrito (Boleta), 3 - Maestría, 4 - PAAE }");
            entity.Property(e => e.PartIdTipoPlaca)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID del Tipo de Placa { 1 - Antiguo/Clásico, 2 - Capacidades diferentes, 3 - Particular, 4 - Público (Taxi / Uber) }");
            entity.Property(e => e.PartIdTipoVehiculo)
                .HasDefaultValueSql("'1'")
                .HasComment("FK ID del Tipo de Vehículo { 1 - Automóvil, 2 - Motocicleta }");
            entity.Property(e => e.PartMarca).HasComment("Marca del Vehículo");
            entity.Property(e => e.PartModelo).HasComment("Modelo del Vehículo");
            entity.Property(e => e.PartNoEmpleado).HasComment("Número de Empleado en caso de ser PAAE");
            entity.Property(e => e.PartNoTelCelular).HasComment("Número de Teléfono Celular del Participante");
            entity.Property(e => e.PartNombre).HasComment("Nombre(s) del Participante");
            entity.Property(e => e.PartPlaca).HasComment("Placa del Vehículo");
            entity.Property(e => e.PartPrimerApellido).HasComment("Primer Apellido del Participante");
            entity.Property(e => e.PartRegistrado)
                .HasDefaultValueSql("'1'")
                .HasComment("Participante registrado para el Sorteo { 0 - No Registrado, 1 - Registrado }");
            entity.Property(e => e.PartSegundoApellido).HasComment("Segundo Apellido del Participante");
            entity.Property(e => e.PartStatus)
                .HasDefaultValueSql("'1'")
                .HasComment("Status del Participante { 0 - Inactivo, 1 - Activo }");
            entity.Property(e => e.PartVersion).HasComment("Versión del Vehículo");

            entity.HasOne(d => d.PartIdCarreraNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdCarrera");

            entity.HasOne(d => d.PartIdEdoRepMexVehiculoNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdEdoRepMexVehiculo");

            entity.HasOne(d => d.PartIdRolNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdRol");

            entity.HasOne(d => d.PartIdSemestreNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdSemestre");

            entity.HasOne(d => d.PartIdTipoParticipanteNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdTipoParticipante");

            entity.HasOne(d => d.PartIdTipoPlacaNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdTipoPlaca");

            entity.HasOne(d => d.PartIdTipoVehiculoNavigation).WithMany(p => p.MsTbParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partIdTipoVehiculo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
