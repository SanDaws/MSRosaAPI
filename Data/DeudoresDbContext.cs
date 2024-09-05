using System;
using System.Collections.Generic;
using MSRosaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MSRosaAPI.Data;

public partial class DeudoresDbContext : DbContext
{
    public DeudoresDbContext()
    {
    }

    public DeudoresDbContext(DbContextOptions<DeudoresDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deudore> Deudores { get; set; }

    public virtual DbSet<EstadosDeudum> EstadosDeuda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=buarmabpi5dp0ox4idcp-mysql.services.clever-cloud.com;port=3306;database=buarmabpi5dp0ox4idcp;uid=u7jpafe9xiyvjxei;password=22p3gY4uC0lRYNvWvOfL", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.15-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Deudore>(entity =>
        {
            entity.HasKey(e => e.IdDeudores).HasName("PRIMARY");

            entity.ToTable("deudores");

            entity.HasIndex(e => e.EstadosDeudaIdEstadosDeuda, "fk_deudores_Estados_deuda_idx");

            entity.Property(e => e.IdDeudores)
                .HasColumnType("int(11)")
                .HasColumnName("idDeudores");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .HasColumnName("apellido");
            entity.Property(e => e.Apodo)
                .HasMaxLength(45)
                .HasColumnName("apodo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.EstadosDeudaIdEstadosDeuda)
                .HasColumnType("int(11)")
                .HasColumnName("Estados_deuda_idEstados_deuda");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.EstadosDeudaIdEstadosDeudaNavigation).WithMany(p => p.Deudores)
                .HasForeignKey(d => d.EstadosDeudaIdEstadosDeuda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_deudores_Estados_deuda");
        });

        modelBuilder.Entity<EstadosDeudum>(entity =>
        {
            entity.HasKey(e => e.IdEstadosDeuda).HasName("PRIMARY");

            entity.ToTable("Estados_deuda");

            entity.HasIndex(e => e.NombreEstado, "nombre_estado_UNIQUE").IsUnique();

            entity.Property(e => e.IdEstadosDeuda)
                .HasColumnType("int(11)")
                .HasColumnName("idEstados_deuda");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(45)
                .HasColumnName("nombre_estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
