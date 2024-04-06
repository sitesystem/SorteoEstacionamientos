using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class SorteoestacionamientosContext : DbContext
{
    private readonly IConfiguration? _config; //Linea agregada
    public SorteoestacionamientosContext()
    {
    }

    public SorteoestacionamientosContext(DbContextOptions<SorteoestacionamientosContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    public virtual DbSet<Catcarrera> Catcarreras { get; set; }

    public virtual DbSet<Catcolore> Catcolores { get; set; }

    public virtual DbSet<Catestado> Catestados { get; set; }

    public virtual DbSet<Catsemestre> Catsemestres { get; set; }

    public virtual DbSet<Cattipoparticipante> Cattipoparticipantes { get; set; }

    public virtual DbSet<Cattipoplaca> Cattipoplacas { get; set; }

    public virtual DbSet<Tbganadore> Tbganadores { get; set; }

    public virtual DbSet<Tbparticipante> Tbparticipantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=sorteoestacionamientos", ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Catcarrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PRIMARY");

            entity
                .ToTable("catcarrera")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Carrera).HasMaxLength(50);
        });

        modelBuilder.Entity<Catcolore>(entity =>
        {
            entity.HasKey(e => e.IdColor).HasName("PRIMARY");

            entity
                .ToTable("catcolores")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.ColorNombre)
                .HasMaxLength(50)
                .HasColumnName("colorNombre");
        });

        modelBuilder.Entity<Catestado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity
                .ToTable("catestados")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.EdoNombre)
                .HasMaxLength(20)
                .HasColumnName("edoNombre");
        });

        modelBuilder.Entity<Catsemestre>(entity =>
        {
            entity.HasKey(e => e.IdSemestre).HasName("PRIMARY");

            entity
                .ToTable("catsemestre")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");
        });

        modelBuilder.Entity<Cattipoparticipante>(entity =>
        {
            entity.HasKey(e => e.IdTipoParticipante).HasName("PRIMARY");

            entity
                .ToTable("cattipoparticipante")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.TipoParticipante).HasMaxLength(50);
        });

        modelBuilder.Entity<Cattipoplaca>(entity =>
        {
            entity.HasKey(e => e.IdTipoPlaca).HasName("PRIMARY");

            entity
                .ToTable("cattipoplaca")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.TipoPlaca)
                .HasMaxLength(30)
                .HasColumnName("tipoPlaca");
        });

        modelBuilder.Entity<Tbganadore>(entity =>
        {
            entity.HasKey(e => e.IdGanador).HasName("PRIMARY");

            entity
                .ToTable("tbganadores")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.GanIdParticipante, "ganIdParticipante");

            entity.Property(e => e.GanIdParticipante).HasColumnName("ganIdParticipante");
            entity.Property(e => e.GanSorteoAm)
                .HasMaxLength(1)
                .HasColumnName("ganSorteoAM");

            entity.HasOne(d => d.GanIdParticipanteNavigation).WithMany(p => p.Tbganadores)
                .HasForeignKey(d => d.GanIdParticipante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbganadores_ibfk_1");
        });

        modelBuilder.Entity<Tbparticipante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PRIMARY");

            entity
                .ToTable("tbparticipantes")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.PartIdCarrera, "partIdCarrera");

            entity.HasIndex(e => e.PartIdColor, "partIdColor");

            entity.HasIndex(e => e.PartIdEstado, "partIdEstado");

            entity.HasIndex(e => e.PartIdSemestre, "partIdSemestre");

            entity.HasIndex(e => e.PartIdTipoParticipante, "partIdTipoParticipante");

            entity.HasIndex(e => e.PartIdTipoPlaca, "partIdTipoPlaca");

            entity.Property(e => e.PartAnio).HasColumnName("partAnio");
            entity.Property(e => e.PartBoleta)
                .HasMaxLength(15)
                .HasColumnName("partBoleta");
            entity.Property(e => e.PartComprobante)
                .HasMaxLength(50)
                .HasColumnName("partComprobante");
            entity.Property(e => e.PartCredencialIpn)
                .HasMaxLength(50)
                .HasColumnName("partCredencialIPN");
            entity.Property(e => e.PartCurp)
                .HasMaxLength(20)
                .HasColumnName("partCURP");
            entity.Property(e => e.PartEmail)
                .HasMaxLength(50)
                .HasColumnName("partEmail");
            entity.Property(e => e.PartIdCarrera).HasColumnName("partIdCarrera");
            entity.Property(e => e.PartIdColor).HasColumnName("partIdColor");
            entity.Property(e => e.PartIdEstado).HasColumnName("partIdEstado");
            entity.Property(e => e.PartIdSemestre).HasColumnName("partIdSemestre");
            entity.Property(e => e.PartIdTipoParticipante).HasColumnName("partIdTipoParticipante");
            entity.Property(e => e.PartIdTipoPlaca).HasColumnName("partIdTipoPlaca");
            entity.Property(e => e.PartLicencia)
                .HasMaxLength(50)
                .HasColumnName("partLicencia");
            entity.Property(e => e.PartMarca)
                .HasMaxLength(50)
                .HasColumnName("partMarca");
            entity.Property(e => e.PartModelo)
                .HasMaxLength(50)
                .HasColumnName("partModelo");
            entity.Property(e => e.PartNoTelefono)
                .HasMaxLength(20)
                .HasColumnName("partNoTelefono");
            entity.Property(e => e.PartNombre)
                .HasMaxLength(50)
                .HasColumnName("partNombre");
            entity.Property(e => e.PartPlaca)
                .HasMaxLength(50)
                .HasColumnName("partPlaca");
            entity.Property(e => e.PartPrimerAp)
                .HasMaxLength(50)
                .HasColumnName("partPrimerAp");
            entity.Property(e => e.PartSegundoAp)
                .HasMaxLength(50)
                .HasColumnName("partSegundoAp");
            entity.Property(e => e.PartStatus)
                .HasColumnType("bit(1)")
                .HasColumnName("partStatus");
            entity.Property(e => e.PartTarjetaCirculacion)
                .HasMaxLength(50)
                .HasColumnName("partTarjetaCirculacion");
            entity.Property(e => e.PartTipoVehiculo)
                .HasMaxLength(45)
                .HasColumnName("partTipoVehiculo");
            entity.Property(e => e.PartVersion)
                .HasMaxLength(50)
                .HasColumnName("partVersion");

            entity.HasOne(d => d.PartIdCarreraNavigation).WithMany(p => p.Tbparticipantes)
                .HasForeignKey(d => d.PartIdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbparticipantes_ibfk_2");

            entity.HasOne(d => d.PartIdColorNavigation).WithMany(p => p.Tbparticipantes)
                .HasForeignKey(d => d.PartIdColor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbparticipantes_ibfk_6");

            entity.HasOne(d => d.PartIdEstadoNavigation).WithMany(p => p.Tbparticipantes)
                .HasForeignKey(d => d.PartIdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbparticipantes_ibfk_4");

            entity.HasOne(d => d.PartIdSemestreNavigation).WithMany(p => p.Tbparticipantes)
                .HasForeignKey(d => d.PartIdSemestre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbparticipantes_ibfk_3");

            entity.HasOne(d => d.PartIdTipoParticipanteNavigation).WithMany(p => p.Tbparticipantes)
                .HasForeignKey(d => d.PartIdTipoParticipante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbparticipantes_ibfk_1");

            entity.HasOne(d => d.PartIdTipoPlacaNavigation).WithMany(p => p.Tbparticipantes)
                .HasForeignKey(d => d.PartIdTipoPlaca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbparticipantes_ibfk_5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
