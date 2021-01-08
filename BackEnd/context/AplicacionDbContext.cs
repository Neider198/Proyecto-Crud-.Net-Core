using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.context
{
  public class AplicacionDbContext : DbContext
  {
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
      : base(options)
    {

    }

    public virtual DbSet<Sexo> Sexos { get; set; }
    public virtual DbSet<TipoIdentificacion> TipoIdentificacions {get; set;}
    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Sexo>(entity =>
      {
        entity.ToTable("Sexos", "basicos");
        entity.Property(e => e.Nombre)
              .HasColumnType("character varying")
              .HasMaxLength(30)
              .IsRequired();
      });

      modelBuilder.Entity<TipoIdentificacion>(entity =>
      {
        entity.ToTable("TipoIdentificacions", "basicos");
        entity.Property(e => e.Nombre)
              .HasColumnType("character varying")
              .HasMaxLength(20)
              .IsRequired();
      });

      modelBuilder.Entity<Persona>(Entity =>
      {
        Entity.Property(e => e.Nombres)
              .HasColumnType("character varying")
              .HasMaxLength(20)
              .IsRequired();

        Entity.Property(e => e.Apellidos)
              .HasColumnType("character varying")
              .HasMaxLength(30)
              .IsRequired();

        Entity.Property(e => e.Direccion)
              .HasColumnType("character varying")
              .HasMaxLength(60)
              .IsRequired();

        Entity.Property(e => e.Telefono)
              .HasColumnType("character varying")
              .HasMaxLength(11)
              .IsRequired();

        Entity.HasOne(d => d.Sexo)
              .WithMany(p => p.Personas)
              .HasForeignKey(d => d.SexoId)
              .HasConstraintName("Personas_Sexos")
              .OnDelete(DeleteBehavior.Cascade);

        Entity.HasOne(d => d.TipoIdentificacion)
              .WithMany(p => p.Personas)
              .HasForeignKey(d => d.TipoIdentififcacionId)
              .HasConstraintName("Personas_TipoIdentificacions")
              .OnDelete(DeleteBehavior.Cascade);
      });
    }
  }
}
