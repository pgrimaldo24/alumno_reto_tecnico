using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Analitycs.Alumno.Infraestructure.Repository.Implementation.Models
{
    public partial class AlumnoBDContext : DbContext
    {
        public AlumnoBDContext()
        {
        }

        public AlumnoBDContext(DbContextOptions<AlumnoBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=AlumnoBD; Integrated Security=true;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("Alumno");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOMICILIO");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_NACIMIENTO");

                entity.Property(e => e.LugarNacimiento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LUGAR_NACIMIENTO");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NACIONALIDAD");

                entity.Property(e => e.NivelEducativo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NIVEL_EDUCATIVO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_DOCUMENTO");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.TipoDocumento).HasColumnName("TIPO_DOCUMENTO");

                entity.Property(e => e.TipoSangre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_SANGRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
